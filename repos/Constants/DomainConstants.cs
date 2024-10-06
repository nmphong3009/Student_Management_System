namespace Constants
{
    public class TimeOut
    {
        public const byte MinutesTimeOut = 5;
        public const byte HoursTimeOut = 1;
    }

    public class Constants
    {
        public const string CONNECTION = "Caching:Redis:Connection";

        public const string IdentityServer = "Authentication:JwtBearer:IdentityServerUrl";

        public const string IdentityServerApi = "Authentication:JwtBearer:IdentityServerApiUrl";

        public const string ClientId = "Authentication:JwtBearer:Audience";

        public const string ClientSecret = "Authentication:JwtBearer:SecurityKey";

        public const int STATUS_CODE_EXCEPTION = 500;

        public const int STATUS_CODE_NOTFOUND = 404;

        public const int STATUS_CODE_FORBID = 403;

        public const int STATUS_CODE_UNAUTHORIZED = 401;

        public const int STATUS_CODE_ERROR = 400;

        public const int STATUS_CODE_SUCCESS = 200;

        public const int STATUS_CODE_NOTACCEPT = 406;

        public const int STATUS_CODE_NOCONTENT = 204;

        public const int STATUS_CODE_MULTI = 207;

        public const string GET = "GET";

        public const string POST = "POST";

        public const string PUT = "PUT";

        public const string DELETE = "DELETE";

        public const string RFI_Name_Prefix = "RFI";

        public const string RFI_Code_Prefix = "VCR";

        // public const string CacheKey_RFICode = "Customer_RFI_Code";

        public const string VI_Culture = "vi-VN";

        public const string OutOfOffice = "Out Of Office";

       
    }

    public class StatusCode
    {
        public const int OK = 200;
        public const int Accepted = 202;
        public const int Multi = 207;
        public const int NoContent = 204;
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int NotAcceptable = 406;
        public const int InternalServerError = 500;
    }

    public class ErrorCode
    {
        public class Common
        {
            /// <summary>
            /// token is invalid
            /// </summary>
            public const string InvalidToken = "MSG-Error0004";

            public const string InvalidExpired = "MSG-Error0005";

            public const string RequiredField = "MSG-Error001";

            public const string SaveToDB = "MSG-Error0002";

            public const string Exception = "MSG-Error0003";

            public const string NoPermission = "MSG-warn-per-001";

            public const string NotFound = "msg-error-notfound";

            public const string TaxcodeNotFound = "msg-error-taxcode-notfound";

            public const string PhoneFormat = "msg-warn-phone";
            public const string PhoneInvalidFormat = "msg-warn-phone-invalid-format";
            public const string EmailInvalidFormat = "msg-warn-email-invalid-format";

            public const string WarningDataNotExist = "MSG_WARNING_DATA_NOT_EXIST";


            public const string Msg_Warn_Taxcode_NoChange = "msg_warn_taxcode_nochange";
            public const string Msg_Warn_Fullname_NoChange = "msg_warn_fullname_nochange";
            public const string Msg_Warn_Business_License_NoChange = "msg_warn_businesslicense_nochange";
            public const string Msg_Warn_Email_And_Status_Existed = "WARNING_EMAIL_AND_STATUS_EXISTED";

            public const string Msg_Error_Core_Vela_Verify = "msg_error_corevela_verify";
            public const string Msg_Error_013 = "msg_error_013";
            public const string Msg_Error_002 = "msg_error_002";
            public const string Msg_Error_Domain_Not_Config = "msg_error_domain_not_config";

            public const string DataNull = "Data_is_empty";
            public const string SaveDataSuccess = "msg_error_save_data_success";
            public const string ErrorSaveFail = "MSG_ERROR_SAVE_FAIL";

           
            public const string TaxCodeExits = "msg_error_005";
            public const string TaxCodeNotFound = "msg_error_004";
            public const string NETWORK_ERROR = "disconnect-vela-server";
        }

        public class JobWorker
        {
            public const string DueDateExpiresLeft = "msg_error_duedate_expires_left";
        }

        

        public class RfiErrorCode
        {
            //public const string MsgDeleteErrorRfi = "msg-error-deleteRfi";
            public static string SuccessChangeStatus = "MSG_SUCCESS_CHANGE_STATUS";
            public const string ErrorChangeStatus = "MSG_ERROR_CHANGE_STATUS";
            public static string CancelledRfiSuccess = "MSG_CANCELLED_RFI_SUCCESS";

            // Message type is ERROR            
           

            // Message type is required fields
            public const string GetByRfiDetail = "MSG_ERROR_GET_BY_RFI_DETAIL";

            public const string OtherRequestNull = "MSG_ERROR_OTHER_REQUEST_NULL";
            public const string CommonSpecificationNull = "MSG_ERROR_COMMON_SPECIFICATION_NULL";
            public const string ErrorRfiNameIsExisted = "MSG_ERROR_RFI_NAME_IS_EXISTED";
        }

        public class UserList
        {
            public const string Vetified = "msg-error-user001";

            public const string ErrorSkoruba = "msg-error-user002";

            public const string AlreadyAdmin = "msg-error-user003";

            public const string UpdateUserError = "msg-error-user004";

            public const string NoVerify = "msg-error-user005";

            public const string ErrorFormatEmail = "User_wrong_format_mail";
        }

        public class Contact
        {
            public const string EmailExits = "msg_error_contact_001";
            public const string AddContactError = "msg_error_contact_002";
            public const string ContactNotExits = "msg_error_contact_003";
            public const string UpdateContactError = "msg_error_contact_005";
            public const string ContactIsNotOwner = "msg_error_contact_006";
            public const string DeleteContactError = "msg_error_contact_007";
            public const string PhoneNumberExits = "msg_error_contact_008";
        }
    }

    public static class ErrMsgCode
    {
        public static class Common
        {
            public const string InvalidInput = "msg-error_invalid_{0}";
            public const string Failed = "msg-error_failed";
            public const string NoPermission = "msg-error_no-permission";
            public const string NotFound = "msg-error_not-found";
            public const string Exception = "msg-error_exception";
            public const string CreateError = "msg-error_create-error";
            public const string UpdateError = "msg-error_update-error";
            public const string DeleteError = "msg-error_delete-error";

            public const string Required = "msg-error_required";
            public const string AlreadyExist = "msg-error_already-exist";
            public const string SkorubaException = "msg-error_skoruba-exception";
        }

    }

    public class InfoMsgCode
    {
        public class Common
        {
            public const string Success = "msg-info_success";
            public const string Created = "msg-info_created";
            public const string PartialCreated = "msg-info-partial-created";
            public const string Updated = "msg-info_updated";
            public const string PartialUpdated = "msg-info-partial-updated";
            public const string Deleted = "msg-info_deleted";
            public const string PartialDeleted = "msg-info-partial-deleted";
        }
       
    }

    public class RFIStatus
    {
        public const string Draft = "Draft";

        public const string New = "New";

        public const string Verifying = "Verifying";

        public const string Amending = "Amending";

        public const string Confirmed = "Confirmed";

        public const string Cancelled = "Cancelled";
    }

    public class ModuleCode
    {
        public const string RFI_CODE = "RFI";
        public const string QUOTATION_CODE = "QUOTATION";
    }


    public class SkorubaApi
    {
        public class User
        {
            public const string Users = "api/Users";
            public const string UsersClaims = "api/Users/UsersClaims";
        }
    }

    public class ApiMethod
    {
        public const string Get = "Get";

        public const string Post = "Post";

        public const string Put = "Put";

        public const string Delete = "Delete";
    }
    public class Permission
    {

        public const string VIEW = "view";
        public const string ADD = "add";
        public const string EDIT = "edit";
        public const string DELETE = "delete";
    }
}
