// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 1f14f2b3c1108e064cc98db3c209e6ad98b10410e9c8202b8323b956becba2a4
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Models.UIMetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [DomainDescriptor]
    public class DeviceAdminDomain
    {
        //[DomainDescription(Name: "Device Admin", Description: "Models for working with and creating device configurations.  This includes things such as actions, attributes and state machines.")]
        public const string DeviceAdmin = "DeviceAdmin";
        //  [DomainDescription(Name: "State Machines", Description: "State Machines are used for a number of system level components.")]
        public const string StateMachines = "StateMachine";
        [DomainDescription(StateMachines)]
        public static DomainDescription StateMachineDomainDescription
        {
            get
            {
                return new DomainDescription()
                {
                    Description = "Provides reusable, data-driven components for building and managing interacting state machines.",
                    DomainType = DomainDescription.DomainTypes.BusinessObject,
                    Name = "State Machine",
                    CurrentVersion = new Core.Models.VersionInfo()
                    {
                        Major = 0,
                        Minor = 8,
                        Build = 001,
                        DateStamp = new DateTime(2016, 12, 20),
                        Revision = 1,
                        ReleaseNotes = "Initial unstable preview"
                    }
                };
            }
        }

        [DomainDescription(DeviceAdmin)]
        public static DomainDescription DeviceAdminDomainDescription
        {
            get
            {
                return new DomainDescription()
                {
                    Description = "A set of classes that contains meta data for managing IoT devices.",
                    DomainType = DomainDescription.DomainTypes.BusinessObject,
                    Name = "Device Administration",
                    CurrentVersion = new Core.Models.VersionInfo()
                    {
                        Major = 0,
                        Minor = 8,
                        Build = 001,
                        DateStamp = new DateTime(2016, 12, 20),
                        Revision = 1,
                        ReleaseNotes = "Initial unstable preview"
                    }
                };
            }
        }
    }
}