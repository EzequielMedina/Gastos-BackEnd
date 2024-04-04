namespace Gastos_BackEnd.Models.Response
{
    public class ResponseBase
    {
        public bool Ok { get; set; }
        public string Error { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

        public void SetError(string mensajeError)
        {
            Ok = false;
            Error = mensajeError;
        }
    }
}
