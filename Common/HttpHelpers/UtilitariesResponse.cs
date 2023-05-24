using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class UtilitariesResponse<T> where T : class, new()
    {
        private IConfigurationLib ConfigurationLib = null;

        public UtilitariesResponse(IConfigurationLib _configurationLib)
        {
            ConfigurationLib = _configurationLib;
        }

        public EResponseBase<T> setResponseBaseForExecuteSQLCommand(int result)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            if (result >= 0)
            {
                response.Code = ConfigurationLib.CodigoExito;
                response.Message = ConfigurationLib.MensajeExitoES;
                response.MessageEN = ConfigurationLib.MensajeExitoEN;
            }
            else
            {
                response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                response.Message = ConfigurationLib.NoDataFoundES;
                response.MessageEN = ConfigurationLib.NoDataFoundEN;
            }
            return response;
        }
        public EResponseBase<T> setResponseBaseForList(IQueryable<T> query)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            if (query == null)
            {
                response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                response.Message = ConfigurationLib.NoDataFoundES;
                response.MessageEN = ConfigurationLib.NoDataFoundEN;
            }
            else
            {
                if (query.ToList().Any())
                {
                    response.Code = 200;
                    response.Message = "La operacion fue realizada con exito";
                    response.MessageEN = "The operation was carried out successfully";
                    response.listado = query.ToList();
                    response.IsResultList = true;
                }
                else
                {
                    response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                    response.Message = ConfigurationLib.NoDataFoundES;
                    response.MessageEN = ConfigurationLib.NoDataFoundEN;
                }
            }
            return response;
        }
        public EResponseBase<T> setResponseBaseForList(List<T> query)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            if (query == null)
            {
                response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                response.Message = ConfigurationLib.NoDataFoundES;
                response.MessageEN = ConfigurationLib.NoDataFoundEN;
            }
            else
            {
                if (query.Any())
                {
                    response.Code = ConfigurationLib.CodigoExito;
                    response.Message = ConfigurationLib.MensajeExitoES;
                    response.MessageEN = ConfigurationLib.MensajeExitoEN;
                    response.listado = query;
                    response.IsResultList = true;
                }
                else
                {
                    response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                    response.Message = ConfigurationLib.NoDataFoundES;
                    response.MessageEN = ConfigurationLib.NoDataFoundEN;
                }
            }
            return response;
        }


        public EResponseBase<T> setResponseBaseForObj(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            if (obj != null)
            {
                response.Code = ConfigurationLib.CodigoExito;
                response.Message = ConfigurationLib.MensajeExitoES;
                response.MessageEN = ConfigurationLib.MensajeExitoEN;
                response.objeto = obj;
            }
            else
            {
                response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                response.Message = ConfigurationLib.NoDataFoundES;
                response.MessageEN = ConfigurationLib.NoDataFoundEN;
            }
            return response;
        }

        public EResponseBase<T> setResponseBaseForObj(string obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            if (obj != null)
            {
                response.Code = ConfigurationLib.CodigoExito;
                response.Message = ConfigurationLib.MensajeExitoES;
                response.MessageEN = ConfigurationLib.MensajeExitoEN;
                response.dato = obj;
            }
            else
            {
                response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                response.Message = ConfigurationLib.NoDataFoundES;
                response.MessageEN = ConfigurationLib.NoDataFoundEN;
            }
            return response;
        }

        public EResponseBase<T> setResponseBaseForValidationExceptionString(IList<string> errors)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoParametrosNoValido;
            response.Message = ConfigurationLib.MensajeParametrosNoValidoES;
            response.MessageEN = ConfigurationLib.MensajeParametrosNoValidoEN;
            //response.FunctionalErrors = errors.ToList();
            return response;
        }
        public EResponseBase<T> setResponseBaseForOK()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = 200;
            response.Message = "La operacion fue realizada con exito";
            response.MessageEN = "The operation was carried out successfully";
            return response;
        }
        public EResponseBase<T> setResponseBaseForOK(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = 200;
            response.Message = "La operacion fue realizada con exito";
            response.MessageEN = "The operation was carried out successfully";
            if (obj != null) response.objeto = obj;
            return response;
        }
        public EResponseBase<T> setResponseBaseForOK(IEnumerable<T> obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoExito;
            response.Message = ConfigurationLib.MensajeExitoES;
            response.MessageEN = ConfigurationLib.MensajeExitoEN;
            if (obj.Any()) { response.listado = obj; response.IsResultList = true; }
            return response;
        }
        public EResponseBase<T> setResponseBaseForExceptionUnexpected()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoErrorNoEspecificado;
            response.Message = ConfigurationLib.MensajeErrorNoEspecificadoES;
            response.MessageEN = ConfigurationLib.MensajeErrorNoEspecificadoEN;
            return response;
        }
        public EResponseBase<T> setResponseBaseForException(Exception ex)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            if (ex is TimeoutException)
            {
                response.Code = ConfigurationLib.CodigoErrorTimeOut;
                response.Message = ConfigurationLib.MensajeErrorTimeOutES;
                response.MessageEN = ConfigurationLib.MensajeErrorTimeOutEN;
            }
            else
            {
                response.Code = ConfigurationLib.CodigoErrorNoEspecificado;
                response.Message = ConfigurationLib.MensajeErrorNoEspecificadoES;
                response.MessageEN = ConfigurationLib.MensajeErrorNoEspecificadoEN;
            }
            //response.TechnicalErrors = ex;
            return response;
        }
        public EResponseBase<T> setResponseBaseForNoAuthorized()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoErrorNoAuthorized;
            response.Message = ConfigurationLib.MensajeErrorNoAuthorizedES;
            response.MessageEN = ConfigurationLib.MensajeErrorNoAuthorizedEN;
            response.listado = new List<T>();
            return response;
        }

        public EResponseBase<T> setResponseBaseForNoDataFound()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoErrorNoDataFound;
            response.Message = ConfigurationLib.NoDataFoundES;
            response.MessageEN = ConfigurationLib.NoDataFoundEN;
            response.listado = new List<T>();
            return response;
        }

        public EResponseBase<T> setResponseBaseExistComment()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoExistsComment;
            response.Message = ConfigurationLib.MensajeExistsCommentES;
            response.MessageEN = ConfigurationLib.MensajeExistsCommentEN;
            response.listado = new List<T>();
            return response;
        }

        public EResponseBase<T> setResponseBaseErrorInsertComment()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoErrorInsertComment;
            response.Message = ConfigurationLib.MensajeErrorInsertCommentES;
            response.MessageEN = ConfigurationLib.MensajeErrorInsertCommentEN;
            response.listado = new List<T>();
            return response;
        }

        public EResponseBase<T> setResponseBaseForParameterNoValid()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoParametrosNoValido;
            response.Message = ConfigurationLib.MensajeParametrosNoValidoES;
            response.MessageEN = ConfigurationLib.MensajeParametrosNoValidoEN;
            response.listado = new List<T>();
            return response;
        }
        public EResponseBase<T> setResponseBaseForDuplicatedData(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoDataExists;
            response.Message = ConfigurationLib.MensajeDataExistsES;
            response.MessageEN = ConfigurationLib.MensajeDataExistsEN;
            if (obj != null) response.objeto = obj;
            return response;
        }
        public EResponseBase<T> setResponseBaseforExistingUser(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoUserExist;
            response.Message = ConfigurationLib.MensajeUserExistES;
            response.MessageEN = ConfigurationLib.MensajeUserExistEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBasePasswordDontMatch(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoPasswordNoCoincide;
            response.Message = ConfigurationLib.MensajePasswordNoCoincideES;
            response.MessageEN = ConfigurationLib.MensajePasswordNoCoincideEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBaseForMissingParameters(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoMissingParameters;
            response.Message = ConfigurationLib.MensajeMissingParametersES;
            response.MessageEN = ConfigurationLib.MensajeMissingParametersEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBaseForSignatureError(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = -1001;
            response.Message = "Firma incorrecta";
            response.MessageEN = "Wrong signature";
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBaseNotEistUserError(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = -1001;
            response.Message = "Usuario no existe";
            response.MessageEN = "Wrong signature";
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBaseForBadCredentials(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoBadCredentials;
            response.Message = ConfigurationLib.MensajeBadCredentialsES;
            response.MessageEN = ConfigurationLib.MensajeBadCredentialsEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBaseForAccountSuspended(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoAccountSuspended;
            response.Message = ConfigurationLib.MensajeAccountSuspendedES;
            response.MessageEN = ConfigurationLib.MensajeAccountSuspendedEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBaseForUserNoExist(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoUserNoExist;
            response.Message = ConfigurationLib.MensajeUserNoExistES;
            response.MessageEN = ConfigurationLib.MensajeUserNoExistEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> eResponseBaseForRoleRegionObligatory(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoRoleRegionObligatory;
            response.Message = ConfigurationLib.MensajeRoleRegionObligatoryES;
            response.MessageEN = ConfigurationLib.MensajeRoleRegionObligatoryEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> eResponseBaseForRoleClinicaObligatory(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoRoleClinicaObligatory;
            response.Message = ConfigurationLib.MensajeRoleClinicaObligatoryES;
            response.MessageEN = ConfigurationLib.MensajeRoleClinicaObligatoryEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBaseExistAssignedInsert(string dato)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoAsignacionDataExists;
            response.Message = ConfigurationLib.MensajeAsignacionExistsES;
            response.MessageEN = ConfigurationLib.MensajeAsignacionExistsEN;
            response.listado = new List<T>();
            response.dato = dato;
            return response;
        }
        public EResponseBase<T> setResponseBaseExistAllAssignedInsert(List<T> obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoAsignacionAllDataExists;
            response.Message = ConfigurationLib.MensajeAsignacionAllExistsES;
            response.MessageEN = ConfigurationLib.MensajeAsignacionAllExistsEN;
            if (obj != null) response.listado = obj;
            return response;
        }
        public EResponseBase<T> setResponseBaseExistSaveOkAssignedInsert(List<T> obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoAsignacionSaveOkDataExists;
            response.Message = ConfigurationLib.MensajeAsignacionSaveOkExistsES;
            response.MessageEN = ConfigurationLib.MensajeAsignacionSaveOkExistsEN;
            if (obj != null) response.listado = obj;
            return response;
        }
        public EResponseBase<T> setResponseBaseExistAssignedSaveFaltaData()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoAsignacionSaveFaltaData;
            response.Message = ConfigurationLib.MensajeAsignacionSaveFaltaDataES;
            response.MessageEN = ConfigurationLib.MensajeAsignacionSaveFaltaDataEN;
            response.listado = new List<T>();
            return response;
        }
        public EResponseBase<T> setResponseBaseForAssignedOK()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoAsignacionExitosa;
            response.Message = ConfigurationLib.MensajeAsignacionExitosaES;
            response.MessageEN = ConfigurationLib.MensajeAsignacionExitosaEN;
            return response;
        }

        public EResponseBase<T> setResponseBaseForSincronizarOK(List<T> obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoSincronizarExitosa;
            response.Message = ConfigurationLib.MensajeSincronizarExitosaES;
            response.MessageEN = ConfigurationLib.MensajeSincronizarExitosaEN;
            response.listado = new List<T>();
            if (obj.Any()) { response.listado = obj; response.IsResultList = true; }
            return response;
        }
        public EResponseBase<T> setResponseBaseForSincronizarNot()
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoSincronizarError;
            response.Message = ConfigurationLib.MensajeSincronizarErrorES;
            response.MessageEN = ConfigurationLib.MensajeSincronizarErrorsaEN;
            return response;
        }
        public EResponseBase<T> setResponseBaseForEmailEnUso(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = ConfigurationLib.CodigoEmailEnUso;
            response.Message = ConfigurationLib.MensajeEmailEnUsoES;
            response.MessageEN = ConfigurationLib.MensajeEmailEnUsoEN;
            if (obj != null) response.objeto = obj;
            return response;
        }

        public EResponseBase<T> setResponseBasePersonExiste(T obj)
        {
            EResponseBase<T> response = new EResponseBase<T>();
            response.Code = -1001;
            response.Message = "La persona ha sido registrada";
            response.MessageEN = "Wrong signature";
            if (obj != null) response.objeto = obj;
            return response;
        }
    }
}
