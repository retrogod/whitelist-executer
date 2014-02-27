﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WhitelistExecuter.Lib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWhitelistExecuter
    {
        [OperationContract]
        ExecutionResult ExecuteCommand(Command command, string relativeWorkingDir);
    }


    [DataContract]
    public enum Command
    {
        [EnumMember]
        GIT_PULL,
        [EnumMember]
        GIT_FETCH,
        [EnumMember]
        GIT_STATUS
    }

    [DataContract]
    public class ExecutionResult
    {
        [DataMember]
        public string StandardOutput;

        [DataMember]
        public string StandardError;

        [DataMember]
        public int ExitCode;
    }
}
