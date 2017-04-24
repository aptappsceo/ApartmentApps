import { Injectable } from '@angular/core';

@Injectable()
export class SignalRService {
    // signalR connection reference
    private connection: SignalR;

    // signalR proxy reference
    private proxy: SignalR.Hub.Proxy;


    constructor() {
        // initialize connection
        this.connection = $.connection;

        // to create proxy give your hub class name as parameter. IMPORTANT: notice that 
        // I followed camel casing in giving class name
        this.proxy = $.connection.hub.createHubProxy('chatHub');

        // define a callback method for proxy
        this.proxy.on('messageReceived', (latestMsg) => this.onMessageReceived(latestMsg));

        this.connection.hub.start();
    }

    private onMessageReceived(latestMsg: string) {
        console.log('New message received: ' + latestMsg);
    }

    // method for sending message
    // tslint:disable-next-line:member-ordering
    public broadcastMessage(msg: string) {
        // invoke method by its name using proxy 
        this.proxy.invoke('sendMessage', msg);
    }

}
