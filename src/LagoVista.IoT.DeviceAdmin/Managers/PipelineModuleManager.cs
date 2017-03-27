using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LagoVista.Core;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class PipelineModuleManager : ManagerBase
    {
        IListenerConfigurationRepo _listenerConfigurationRepo;
        IInputTranslatorConfigurationRepo _inputTranslatorConfigurationRepo;
        ISentinelConfigurationRepo _sentinalConfigurationRepo;
        IOutputTranslatorConfigurationRepo _outputTranslatorConfigurationRepo;
        ITransmitterConfigurationRepo _transmitterConfigurationRepo;
        IPipelineModuleConfigurationRepo _pipelineConfiguratoinRepo;

        public PipelineModuleManager(IListenerConfigurationRepo listenerConfigurationRep, IInputTranslatorConfigurationRepo inputConfigurationRepo, ISentinelConfigurationRepo sentinalConfigurationRepo,
               IOutputTranslatorConfigurationRepo outputConfigurationRepo, ITransmitterConfigurationRepo translatorConfigurationRepo, IPipelineModuleConfigurationRepo pipelineConfigrationRepo)
        {
            _listenerConfigurationRepo = listenerConfigurationRep;
            _inputTranslatorConfigurationRepo = inputConfigurationRepo;
            _sentinalConfigurationRepo = sentinalConfigurationRepo;
            _outputTranslatorConfigurationRepo = outputConfigurationRepo;
            _transmitterConfigurationRepo = translatorConfigurationRepo;
            _pipelineConfiguratoinRepo = pipelineConfigrationRepo;
        }

        #region Add Methods
        public async Task<InvokeResult> AddListenerConfigurationAsync(ListenerConfiguration listenerConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(listenerConfiguration, org, user, AuthorizeActions.Create);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(listenerConfiguration, Actions.Create);
            if (result.IsValid)
            {
                await _listenerConfigurationRepo.AddListenerConfigurationAsync(listenerConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddInputTranslatorConfigurationAsync(InputTranslatorConfiguration inputTranslatorConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(inputTranslatorConfiguration, org, user, AuthorizeActions.Create);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(inputTranslatorConfiguration, Actions.Create);
            if (result.IsValid)
            {
                await _inputTranslatorConfigurationRepo.AddInputTranslatorConfigurationAsync(inputTranslatorConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddSentinelConfigurationAsync(SentinelConfiguration sentinalConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(sentinalConfiguration, org, user, AuthorizeActions.Create);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(sentinalConfiguration, Actions.Create);
            if (result.IsValid)
            {
                await _sentinalConfigurationRepo.AddSentinelConfigurationAsync(sentinalConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddOutputTranslatorConfigurationAsync(OutputTranslatorConfiguration outputTranslatorConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(outputTranslatorConfiguration, org, user, AuthorizeActions.Create);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(outputTranslatorConfiguration, Actions.Create);
            if (result.IsValid)
            {
                await _outputTranslatorConfigurationRepo.AddOutputTranslatorConfigurationAsync(outputTranslatorConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddTransmitterConfigurationAsync(TransmitterConfiguration transmitterConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(transmitterConfiguration, org, user, AuthorizeActions.Create);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(transmitterConfiguration, Actions.Create);
            if (result.IsValid)
            {
                await _transmitterConfigurationRepo.AddTransmitterConfigurationAsync(transmitterConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddPipelineModuleConfigurationAsync(PipelineModuleConfiguration pipelineModuleConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(pipelineModuleConfiguration, org, user, AuthorizeActions.Create);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(pipelineModuleConfiguration, Actions.Create);
            if (result.IsValid)
            {
                await _pipelineConfiguratoinRepo.AddPipelineModuleConfigurationAsync(pipelineModuleConfiguration);
            }

            return result.ToActionResult();
        }
        #endregion

        #region Update Methods
        public async Task<InvokeResult> UpdateListenerConfigurationAsync(ListenerConfiguration listenerConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(listenerConfiguration, org, user, AuthorizeActions.Update);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(listenerConfiguration, Actions.Create);
            if (result.IsValid)
            {
                listenerConfiguration.LastUpdatedBy = user;
                listenerConfiguration.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _listenerConfigurationRepo.UpdateListenerConfigurationAsync(listenerConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> UpdatedInputTranslatorConfigurationAsync(InputTranslatorConfiguration inputTranslatorConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(inputTranslatorConfiguration, org, user, AuthorizeActions.Update);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(inputTranslatorConfiguration, Actions.Create);
            if (result.IsValid)
            {
                inputTranslatorConfiguration.LastUpdatedBy = user;
                inputTranslatorConfiguration.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _inputTranslatorConfigurationRepo.UpdateInputTranslatorConfigurationAsync(inputTranslatorConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> UpdatedSentinelConfigurationAsync(SentinelConfiguration sentinalConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(sentinalConfiguration, org, user, AuthorizeActions.Update);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(sentinalConfiguration, Actions.Create);
            if (result.IsValid)
            {
                sentinalConfiguration.LastUpdatedBy = user;
                sentinalConfiguration.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _sentinalConfigurationRepo.UpdateSentinelConfigurationAsync(sentinalConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> UpdateOutputTranslatorConfigurationAsync(OutputTranslatorConfiguration outputTranslatorConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(outputTranslatorConfiguration, org, user, AuthorizeActions.Update);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(outputTranslatorConfiguration, Actions.Create);
            if (result.IsValid)
            {
                outputTranslatorConfiguration.LastUpdatedBy = user;
                outputTranslatorConfiguration.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _outputTranslatorConfigurationRepo.UpdateOutputTranslatorConfigurationAsync(outputTranslatorConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> UpdatedTransmitterConfigurationAsync(TransmitterConfiguration transmitterConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(transmitterConfiguration, org, user, AuthorizeActions.Update);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(transmitterConfiguration, Actions.Create);
            if (result.IsValid)
            {
                transmitterConfiguration.LastUpdatedBy = user;
                transmitterConfiguration.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _transmitterConfigurationRepo.UpdateTransmitterConfigurationAsync(transmitterConfiguration);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> UpdatePipelineModuleConfigurationAsync(PipelineModuleConfiguration pipelineModuleConfiguration, EntityHeader org, EntityHeader user)
        {
            var authResult = await AuthorizeAsync(pipelineModuleConfiguration, org, user, AuthorizeActions.Update);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            var result = Validator.Validate(pipelineModuleConfiguration, Actions.Create);
            if (result.IsValid)
            {
                pipelineModuleConfiguration.LastUpdatedBy = user;
                pipelineModuleConfiguration.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _pipelineConfiguratoinRepo.UpdatePipelineModuleConfigurationAsync(pipelineModuleConfiguration);
            }

            return result.ToActionResult();
        }
        #endregion

        #region Get Method
        public async Task<ListenerConfiguration> GetListenerConfigurationAsync(String id, EntityHeader org, EntityHeader user)
        {
            var listnerConfiguration = await _listenerConfigurationRepo.GetListenerConfigurationAsync(id);
            var authResult = await AuthorizeAsync(listnerConfiguration, org, user, AuthorizeActions.Read);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            return listnerConfiguration;
        }

        public async Task<InputTranslatorConfiguration> GetInputTranslatorConfigurationAsync(String id, EntityHeader org, EntityHeader user)
        {
            var inputTranslatorConfiguration = await _inputTranslatorConfigurationRepo.GetInputTranslatorConfigurationAsync(id);
            var authResult = await AuthorizeAsync(inputTranslatorConfiguration, org, user, AuthorizeActions.Read);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            return inputTranslatorConfiguration;
        }

        public async Task<SentinelConfiguration> GetSentinelConfigurationAsync(String id, EntityHeader org, EntityHeader user)
        {
            var sentinalConfiguration = await _sentinalConfigurationRepo.GetSentinelConfigurationAsync(id);
            var authResult = await AuthorizeAsync(sentinalConfiguration, org, user, AuthorizeActions.Read);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            return sentinalConfiguration;
        }

        public async Task<OutputTranslatorConfiguration> GetOutputTranslatorConfigurationAsync(String id, EntityHeader org, EntityHeader user)
        {
            var outputTranslator = await _outputTranslatorConfigurationRepo.GetOutputTranslatorConfigurationAsync(id);
            var authResult = await AuthorizeAsync(outputTranslator, org, user, AuthorizeActions.Read);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            return outputTranslator;
        }

        public async Task<TransmitterConfiguration> GetTransmitterConfigurationAsync(String id, EntityHeader org, EntityHeader user)
        {
            var transmitterConfiguration = await _transmitterConfigurationRepo.GetTransmitterConfigurationAsync(id);
            var authResult = await AuthorizeAsync(transmitterConfiguration, org, user, AuthorizeActions.Read);
            if (!authResult.IsAuthorized)
            {
                throw new NotAuthorizedException(authResult);
            }

            return transmitterConfiguration;
        }

        public async Task<PipelineModuleConfiguration> GetPipelienModuleConfigurationAsync(String id, EntityHeader org, EntityHeader user)
        {
            var pipelineModuleConfiguration = await _pipelineConfiguratoinRepo.GetPipelineModuleConfigurationAsync(id);
            var authResult = await AuthorizeAsync(pipelineModuleConfiguration, org, user, AuthorizeActions.Read);
            if(!authResult.IsAuthorized)
            { 
                throw new NotAuthorizedException(authResult);
            }

            return pipelineModuleConfiguration;
        }
        #endregion

        #region Get For Org
        public Task<IEnumerable<PipelineModuleConfigurationSummary>> GetListenerConfiugrationsForOrgAsync(String orgId)
        {
            return _listenerConfigurationRepo.GetListenerConfigurationsForOrgsAsync(orgId);
        }
        public Task<IEnumerable<PipelineModuleConfigurationSummary>> GetInputTranslatorConfiugrationsForOrgAsync(String orgId)
        {
            return _inputTranslatorConfigurationRepo.GetInputTranslatorConfigurationsForOrgsAsync(orgId);
        }
        public Task<IEnumerable<PipelineModuleConfigurationSummary>> GetSentinelConfiugrationsForOrgAsync(String orgId)
        {
            return _sentinalConfigurationRepo.GetSentinelConfigurationsForOrgsAsync(orgId);
        }
        public Task<IEnumerable<PipelineModuleConfigurationSummary>> GetOutputTranslatorConfiugrationsForOrgAsync(String orgId)
        {
            return _outputTranslatorConfigurationRepo.GetOutputTranslatorConfigurationsForOrgsAsync(orgId);
        }
        public Task<IEnumerable<PipelineModuleConfigurationSummary>> GetTransmitterConfiugrationsForOrgAsync(String orgId)
        {
            return _transmitterConfigurationRepo.GetTransmitterConfigurationsForOrgsAsync(orgId);
        }
        public Task<IEnumerable<PipelineModuleConfigurationSummary>> GetPipelineModuleConfiugrationsForOrgAsync(String orgId)
        {
            return _pipelineConfiguratoinRepo.GetPipelineModuleConfigurationsForOrgsAsync(orgId);
        }
        #endregion

        #region Delete Methods
        public async Task<InvokeResult> DeleteListenerAsync(String id, EntityHeader org, EntityHeader user)
        {
            var listenerConfiguration =  await _listenerConfigurationRepo.GetListenerConfigurationAsync(id);

            var authResult = await AuthorizeAsync(listenerConfiguration, org, user, AuthorizeActions.Delete);
            if(authResult.IsAuthorized)
            {
                await _listenerConfigurationRepo.DeleteListenerConfigurationAsync(listenerConfiguration.Id);
            }

            return authResult.ToActionResult();
        }

        public async Task<InvokeResult> DeleteInputTranslatorAsync(String id, EntityHeader org, EntityHeader user)
        {
            var inputTranslatorConfiguration = await _inputTranslatorConfigurationRepo.GetInputTranslatorConfigurationAsync(id);

            var authResult = await AuthorizeAsync(inputTranslatorConfiguration, org, user, AuthorizeActions.Delete);
            if (authResult.IsAuthorized)
            {
                await _listenerConfigurationRepo.DeleteListenerConfigurationAsync(inputTranslatorConfiguration.Id);
            }

            return authResult.ToActionResult();
        }

        public async Task<InvokeResult> DeleteSentinelAsync(String id, EntityHeader org, EntityHeader user)
        {
            var sentinalConfiguration = await _sentinalConfigurationRepo.GetSentinelConfigurationAsync(id);

            var authResult = await AuthorizeAsync(sentinalConfiguration, org, user, AuthorizeActions.Delete);
            if (authResult.IsAuthorized)
            {
                await _sentinalConfigurationRepo.DeleteSentinelConfigurationAsync(sentinalConfiguration.Id);
            }

            return authResult.ToActionResult();
        }

        public async Task<InvokeResult> DeleteOutputTranslatorAsync(String id, EntityHeader org, EntityHeader user)
        {
            var outputTranslatorConfiguration = await _outputTranslatorConfigurationRepo.GetOutputTranslatorConfigurationAsync(id);

            var authResult = await AuthorizeAsync(outputTranslatorConfiguration, org, user, AuthorizeActions.Delete);
            if (authResult.IsAuthorized)
            {
                await _outputTranslatorConfigurationRepo.DeleteOutputTranslatorConfigurationAsync(outputTranslatorConfiguration.Id);
            }

            return authResult.ToActionResult();
        }

        public async Task<InvokeResult> DeleteTransmitterAsync(String id, EntityHeader org, EntityHeader user)
        {
            var transmitterConfiguration = await _transmitterConfigurationRepo.GetTransmitterConfigurationAsync(id);

            var authResult = await AuthorizeAsync(transmitterConfiguration, org, user, AuthorizeActions.Delete);
            if (authResult.IsAuthorized)
            {
                await _transmitterConfigurationRepo.DeleteTransmitterConfigurationAsync(transmitterConfiguration.Id);
            }

            return authResult.ToActionResult();
        }

        public async Task<InvokeResult> DeletePipelineModuleAsync(String id, EntityHeader org, EntityHeader user)
        {
            var pipelineModuleConfiguration = await _pipelineConfiguratoinRepo.GetPipelineModuleConfigurationAsync(id);

            var authResult = await AuthorizeAsync(pipelineModuleConfiguration, org, user, AuthorizeActions.Delete);
            if (authResult.IsAuthorized)
            {
                await _pipelineConfiguratoinRepo.DeletePipelineModuleConfigurationAsync(pipelineModuleConfiguration.Id);
            }

            return authResult.ToActionResult();
        }
        #endregion
    }
}
