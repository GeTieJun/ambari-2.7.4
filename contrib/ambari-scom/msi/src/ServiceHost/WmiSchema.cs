//Licensed to the Apache Software Foundation (ASF) under one or more
//contributor license agreements.  See the NOTICE file distributed with
//this work for additional information regarding copyright ownership.
//The ASF licenses this file to You under the Apache License, Version 2.0
//(the "License"); you may not use this file except in compliance with
//the License.  You may obtain a copy of the License at
//     http://www.apache.org/licenses/LICENSE-2.0
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

namespace WMI
{
    public enum ServiceType
    {
        KernalDriver = 1,
        FileSystemDriver = 2,
        Adapter = 4,
        RecognizerDriver = 8,
        OwnProcess = 16,
        ShareProcess = 32,
        InteractiveProcess = 256,
    }

    public enum ErrorControl
    {
        UserNotNotified = 0,
        UserNotified = 1,
        SystemRestartedWithLastKnownGoodConfiguration = 2,
        SystemAttemptsToStartWithAGoodConfiguration = 3
    }

    public enum StartMode
    {
        /// <summary>
        /// Device driver started by the operating system loader. This value is valid only for driver services.
        /// </summary>
        Boot,
        /// <summary>
        /// Device driver started by the operating system initialization process. This value is valid only for driver services.
        /// </summary>
        System,
        /// <summary>
        /// Service to be started automatically by the Service Control Manager during system startup.
        /// </summary>
        Automatic,
        /// <summary>
        /// Service to be started by the Service Control Manager when a process calls the StartService method.
        /// </summary>
        Manual,
        /// <summary>
        /// Service that can no longer be started.
        /// </summary>
        Disabled,
    }

    [WmiClassName("Win32_Service")]
    public interface Win32Services : IWmiCollection
    {
        // ReturnValue Create(bool desktopInteract, string displayName, int errorControl, string loadOrderGroup, string loadOrderGroupDependencies, string name, string pathName, string serviceDependencies, string serviceType, string startMode, string startName, string startPassword);
        void Create(string name, string displayName, string pathName, ServiceType serviceType, ErrorControl errorControl, StartMode startMode, bool desktopInteract, string[] serviceDependencies);

        Win32Service Select(string name);
    }

    public interface Win32Service : IWmiObject
    {
        string Description { get; set; }
        bool Started { get; }
        void Delete();
        void StartService();
        void StopService();
    }
}
