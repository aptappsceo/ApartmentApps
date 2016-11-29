using System;
using ObjCRuntime;

[assembly: LinkWith ("libSCLAlertViewLib.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator64 | LinkTarget.x86_64, SmartLink = true, ForceLoad = true)]
