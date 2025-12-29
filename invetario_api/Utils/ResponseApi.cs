using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace invetario_api.utils
{
    public class ResponseApi<T>
    {

        public int code { get; set; }

        public string message { get; set; }

        public T? data { get; set; }

        public bool success { get; set; }

        public Dictionary<string, IEnumerable<string>>? errors { get; set; }

        public ResponseApi(bool _success, int _code, string _message, T? _data)
        {
            code = _code;
            message = _message;
            data = _data;
            success = _success;
        }
        public ResponseApi(bool _success, int _code, string _message)
        {
            code = _code;
            message = _message;
            success = _success;
        }

        public ResponseApi(Dictionary<string, IEnumerable<string>>? _errors)
        {
            code = 400;
            message = "Bad Request";
            success = false;
            errors = _errors;
        }


        public static ResponseApi<T> Success(int _code, string _message, T? _data)
        {
            return new ResponseApi<T>(true, _code, _message, _data);
        }

        public static ResponseApi<object> NotFound(int _code, string _message)
        {
            return new ResponseApi<object>(false, _code, _message);
        }

        public static ResponseApi<T> ErrorModel(Dictionary<string, IEnumerable<string>>? _errors)
        {
            return new ResponseApi<T>(_errors);
        }

    }
}
