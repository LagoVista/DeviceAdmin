// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 89798c1c33388ce11a536bef813addbddd50c94ac0546c71951401e8eb009fba
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public abstract class NodeBase : IoTModelBase
    {
        public NodeBase()
        {
            OutgoingConnections = new ObservableCollection<Connection>();
            IncomingConnections = new ObservableCollection<Connection>();
            DiagramLocations = new ObservableCollection<DiagramLocation>();
        }

        public const string NodeType_Input = "workflowinput";
        public const string NodeType_Attribute = "attribute";
        public const string NodeType_Script = "script";
        public const string NodeType_InputCommand = "inputcommand";
        public const string NodeType_Timer = "timer";
        public const string NodeType_StateMachine = "statemachine";
        public const string NodeType_OutputCommand = "outputcommand";

        public abstract string NodeType { get; }

        public ObservableCollection<Connection> OutgoingConnections { get; set; }
        public ObservableCollection<Connection> IncomingConnections { get; set; }

        public ObservableCollection<DiagramLocation> DiagramLocations { get; set; }

        /// <summary>
        /// Make sure that the incoming and outgoing connections exists and valid for the core information.
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        protected ValidationResult ValidateNodeBase(DeviceWorkflow workflow)
        {
            var result = new ValidationResult();

            if(NodeType != NodeType_Input &&
                NodeType != NodeType_Attribute &&
                NodeType != NodeType_Script &&
                NodeType != NodeType_InputCommand &&
                NodeType != NodeType_Timer &&
                NodeType != NodeType_StateMachine &&
                NodeType != NodeType_OutputCommand)
            {
                result.Errors.Add(new ErrorMessage($"Invalid node type: {NodeType}", true));
            }               

            foreach(var connection in OutgoingConnections)
            {
                if (String.IsNullOrEmpty(connection.NodeType)) result.Errors.Add(new ErrorMessage($"Missing Node Type for outgoing connection on node {Name}", true));
                if (String.IsNullOrEmpty(connection.NodeKey)) result.Errors.Add(new ErrorMessage($"Missing Node Key for outgoing connection on node {Name}", true));
                if (String.IsNullOrEmpty(connection.NodeName)) result.Errors.Add(new ErrorMessage($"Missing Node Name for outgoing connection on node {Name}", true));
                if (!result.Successful) return result;

                switch (connection.NodeType)
                {
                    case NodeType_Input:
                        if (!workflow.Inputs.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find outgoing connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    case NodeType_Attribute:
                        if (!workflow.Attributes.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find outgoing connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    case NodeType_InputCommand:
                        if (!workflow.InputCommands.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find outgoing connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    case NodeType_OutputCommand:
                        if (!workflow.OutputCommands.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find outgoing connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    case NodeType_StateMachine:
                        if (!workflow.StateMachines.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find outgoing connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    default: result.Errors.Add(new ErrorMessage($"Unknown outgoing connection node type {connection.NodeType} on node {Name}", true)); break;
                }
            }

            foreach(var connection in IncomingConnections)
            {
                if (String.IsNullOrEmpty(connection.NodeType)) result.Errors.Add(new ErrorMessage($"Missing Node type for incoming connection on node {Name}", true));
                if (String.IsNullOrEmpty(connection.NodeKey)) result.Errors.Add(new ErrorMessage($"Missing Node Key for incoming connection on node {Name}", true));
                if (String.IsNullOrEmpty(connection.NodeName)) result.Errors.Add(new ErrorMessage($"Missing Node Name for incoming connection on node {Name}", true));
                if (!result.Successful) return result;

                switch (connection.NodeType)
                {
                    case NodeType_Input:
                        if (!workflow.Inputs.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find incoming connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    case NodeType_Attribute:
                        if (!workflow.Attributes.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find incoming connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    case NodeType_InputCommand:
                        if (!workflow.InputCommands.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find incoming connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    case NodeType_OutputCommand:
                        if (!workflow.OutputCommands.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find incoming connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    case NodeType_StateMachine:
                        if (!workflow.StateMachines.Where(inp => inp.Key == connection.NodeKey).Any())
                        {
                            result.Errors.Add(new ErrorMessage($"On Node Type {NodeType}, Node {Name}, could not find incoming connection of type {connection.NodeType}, Node {connection.NodeKey}."));
                        }
                        break;
                    default: result.Errors.Add(new ErrorMessage($"Unknown incoming connection node type {connection.NodeType} on node {Name}", true)); break;

                }
            }

            return result;
        }

        protected void ValidateStateMachine(ValidationResult result, DeviceWorkflow workflow, Connection connection)
        {
            if (EntityHeader.IsNullOrEmpty(connection.StateMachineEvent))
            {
                result.Errors.Add(new ErrorMessage($"Transition Event is empty from {Name} to State Machine {connection.NodeName} does not exist on that state machine."));
            }
            else
            {                
                var outputStateMachine = workflow.StateMachines.Where(stm => stm.Key == connection.NodeKey).FirstOrDefault();
                if (outputStateMachine != null)
                {
                    if (!outputStateMachine.Events.Where(evt => evt.Key == connection.StateMachineEvent.Id).Any()) result.Errors.Add(new ErrorMessage($"Transition Event {connection.StateMachineEvent.Text} from {Name} to {outputStateMachine.Name} does not exist on that state machine."));
                }
                else
                {
                    throw new InvalidOperationException($"Could not find state machine with key {connection.NodeKey}.");
                }
            }
        }
    }
}
