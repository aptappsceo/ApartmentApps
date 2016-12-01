//------------------------------------------------------------------------------
// <copyright file="ResourcePool.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Azure.Utilities
{
    using System.Collections;
    using System.Threading;
    using System;

    /*
     * ResourcePool provides a place to store expensive resources,
     * such as network connections, that you want to dispose of when
     * they are underused. A resource pool can be configured to timeout
     * resources at a given interval, and to have a max limit of resources.
     */
    class ResourcePool : IDisposable {
        ArrayList       _resources;     // the resources
        int             _iDisposable;   // resources below this index are candidates for disposal
        int             _max;           // max number of resources
        Timer           _timer;         // periodic timer
        TimerCallback   _callback;      // callback delegate
        TimeSpan        _interval;      // callback interval
        bool            _disposed;

        internal ResourcePool(TimeSpan interval, int max) {
            _interval = interval;
            _resources = new ArrayList(4);
            _max = max;
            _callback = new TimerCallback(this.TimerProc);
        }

        ~ResourcePool() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
        }
        
        void Dispose(bool disposing) {
            lock (this) {
                if (!_disposed) {
                    if (_resources != null) {
                        foreach (IDisposable resource in _resources) {
                            resource.Dispose();
                        }

                        _resources.Clear();
                    }

                    if (_timer != null) {
                        _timer.Dispose();
                    }

                    _disposed = true;

                    // Suppress finalization of this disposed instance.
                    if (disposing)
                    {
                        GC.SuppressFinalize(this);
                    }
                }
            }
        }

        internal object RetrieveResource() {
            object result = null;

            // avoid lock in common case
            if (_resources.Count != 0) {
                lock (this) {
                    if (!_disposed) {
                        if (_resources.Count == 0) {
                            result = null;
                        } else {
                            result = _resources[_resources.Count-1];
                            _resources.RemoveAt(_resources.Count-1);
                            if (_resources.Count < _iDisposable) {
                                _iDisposable = _resources.Count;
                            }
                        }
                    }
                }
            }
    
            return result;
        }

        internal void StoreResource(IDisposable o) {

            lock (this) {
                if (!_disposed) {
                    if (_resources.Count < _max) {
                        _resources.Add(o);
                        o = null;
                        if (_timer == null) {

#if DBG
                            if (!Debug.IsTagPresent("Timer") || Debug.IsTagEnabled("Timer"))
#endif
                            {
                                _timer = new Timer(_callback, null, _interval, _interval);
                            }
                        }
                    }
                }
            }

            if (o != null) {
                o.Dispose();
            }
        }

        void TimerProc(Object userData) {
            IDisposable[] a = null;

            lock (this) {
                if (!_disposed) {
                    if (_resources.Count == 0) {
                        if (_timer != null) {
                            _timer.Dispose();
                            _timer = null;
                        }

                        return;
                    }

                    a = new IDisposable[_iDisposable];
                    _resources.CopyTo(0, a, 0, _iDisposable);
                    _resources.RemoveRange(0, _iDisposable);

                    // It means that whatever remain in _resources will be disposed 
                    // next time the timer proc is called.
                    _iDisposable = _resources.Count;
                }
            }

            if (a != null) {
                for (int i = 0; i < a.Length; i++) {
                    try {
                        a[i].Dispose();
                    }
                    catch {
                        // ignore all errors
                    }
                }
            }
        }

#if DBG
        internal void DebugValidate() {
            Debug.CheckValid(_resources != null, "_resources != null");

            Debug.CheckValid(0 <= _iDisposable && _iDisposable <= _resources.Count,
                             "0 <= _iDisposable && _iDisposable <= _resources.Count" +
                             ";_iDisposable=" + _iDisposable +
                             ";_resources.Count=" + _resources.Count);

            Debug.CheckValid(_interval > TimeSpan.Zero, "_interval > TimeSpan.Zero" +
                             ";_interval=" + _interval);
        }
#endif
    }
}

