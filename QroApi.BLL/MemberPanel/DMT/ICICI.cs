using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using QroApi.DLL;
using System.Data.SqlClient;

namespace QroApi.BLL
{
    public class ICICI
    {
        static readonly SQLHelper _iSqlHelper;
        public static string _path = "";
        public static string AGGRID = "OTOE0427";
        public static string AGGRNAME = "SIAASU";
        public static string CORPID = "581441962";
        public static string USERID = "KIRANPRA";
        public static string URN = "SR209594054";
        public static string DEBITACC = "677205601373";
        static ICICI()
        {
            SQLHelper iSqlHelper = new SQLHelper();
            _iSqlHelper = iSqlHelper;
        }
        private static Random random = new Random();
        private static string txnUrl = "";
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static async Task<string> TransactionRequest(string uniqueId, decimal amount, string remark, string payeeName,string account,string ifsc,string txnMode)
        {
            //string d = "C+uZUUiM36wX6RuZmC//Ln+7BjFOyqdlFA55KaB+LE42IK39McPUKrPCM1My3GrIDbdaS/cLqrGCy9XSpjsjGPI6fv6ydrv++O76aezN86WUjDdbMlYCZdX6os+HKdUX+F/TXqVJnw89OziUnxLxw9LxZnXj1g0rXHiQX4DqnW/NS6yw+O5GANRlxoZdBvYemT6041/llE0U0PPkXBb222McY9WYRIdfyqE5KzX9kUn1ZeMRw+mWVfbVjhUZVYxBXdHNHDKZkjJJSxPCRHDpsnRzZoxn9PPD1t7IbOdT8yjLd3PVB+yxpF/oNJcPMTdcxNMZtRmSqj8IXOxv8FnZg2ei21y10myrUrjIqBs/dCdLBVZaHiT3ydt7Oyulka3GR3HyK+3vsp50nWIbaRqKJOJQTgeuaUYHydG+/DHSJX3ppUgK4Tu7bJD9sW4WZjcFxQfYODqU+2rELImNGsw4JxkgGxqtEbMzzmX+qZ7E2puHYX6thzweAq+/YNrfLV152lOJFGzHOHS+yt0HVk6s9SkYNLWRB3+C9vCt2G2hAuv2rYkHL2XNtatnQkK0bHb5YqDKbrwR2wp38lQvvCu1fegrlgFKyWuIHRbVDIRSc7m0Q6+4bDoaa+7LkNB2JK6HFC4SahTXjMF1sydO+/qvS3Bjw/NoPxh7rZYdCfi6N9c=";
            //byte[] _dataDecrypt = Convert.FromBase64String(d);
            //string _decrypt = RSA.Decrypt(d); 

            //var _parameterList = new Dictionary<string, object>();
            //_parameterList.Add("AGGRNAME", "SIAASU");
            //_parameterList.Add("UNIQUEID", uniqueId);
            //_parameterList.Add("DEBITACC", "000451000301");
            //_parameterList.Add("CREDITACC", "000405001257");
            //_parameterList.Add("IFSC", "ICIC0000011");
            //_parameterList.Add("AMOUNT","1.00");
            //_parameterList.Add("CURRENCY", "INR");
            //_parameterList.Add("TXNTYPE", "TPA");
            //_parameterList.Add("PAYEENAME", payeeName);
            //_parameterList.Add("REMARKS", remark);
            //_parameterList.Add("CORPID", "PRACHICIB1");
            //_parameterList.Add("USERID", "USER3");
            //_parameterList.Add("AGGRID", "OTOE0427");
            //_parameterList.Add("URN", "SR209594054");
            // _parameterList.Add("WORKFLOW_REQD", "N");

            //var payload = JsonConvert.SerializeObject(_parameterList);

            //string response = await invokeRequest(payload, "https://apibankingonesandbox.icicibank.com/api/Corporate/CIB/v1/Transaction", "POST");////https://apibankingsandbox.icicibank.com/api/MerchantAPI/UPI/v0/CollectPay2/400753
            var _parameterList = new Dictionary<string, object>();
            _parameterList.Add("AGGRNAME", AGGRNAME);
            _parameterList.Add("UNIQUEID", uniqueId);
            _parameterList.Add("DEBITACC", DEBITACC);
            _parameterList.Add("CREDITACC", account);
            _parameterList.Add("IFSC",ifsc);
            _parameterList.Add("AMOUNT",amount.ToString());
            _parameterList.Add("CURRENCY", "INR");
            _parameterList.Add("TXNTYPE", txnMode);
            _parameterList.Add("PAYEENAME", payeeName);
            _parameterList.Add("REMARKS", remark);
            _parameterList.Add("CORPID", CORPID);
            _parameterList.Add("USERID",USERID);
            _parameterList.Add("AGGRID", AGGRID);
            _parameterList.Add("URN", URN);
            //_parameterList.Add("WORKFLOW_REQD", "N");

            var payload = JsonConvert.SerializeObject(_parameterList);

            string response = await invokeRequest(payload, "https://apibankingone.icicibank.com/api/Corporate/CIB/v1/Transaction", "POST",uniqueId);
            return response;
        }
        public static async Task<string> TransactionStatusRequest(string uniqueId)
        {
            
            var _parameterList = new Dictionary<string, object>();           
            _parameterList.Add("UNIQUEID", uniqueId);
            //_parameterList.Add("AGGRNAME", AGGRNAME);
            _parameterList.Add("CORPID", CORPID);
            _parameterList.Add("USERID", USERID);
            _parameterList.Add("AGGRID", AGGRID);
            _parameterList.Add("URN", URN);        

            var payload = JsonConvert.SerializeObject(_parameterList);

            string response = await invokeRequest(payload, "https://apibankingone.icicibank.com/api/Corporate/CIB/v1/TransactionInquiry", "POST","");

            return response;
        }

        public static async Task<string> BalanceEnquiry()
        {

            var _parameterList = new Dictionary<string, object>();         
            _parameterList.Add("CORPID", CORPID);
            //_parameterList.Add("AGGRNAME", AGGRNAME);
            _parameterList.Add("USERID", USERID);
            _parameterList.Add("AGGRID",AGGRID);
            _parameterList.Add("URN", URN);
            _parameterList.Add("ACCOUNTNO", DEBITACC);
            var payload = JsonConvert.SerializeObject(_parameterList);
            string response = await invokeRequest(payload, "https://apibankingone.icicibank.com/api/Corporate/CIB/v1/BalanceInquiry", "POST","");

            return response;
        }
        private static async Task<string> invokeRequest(string data, string url, string method, string uniqueId,string callName = "")
        {
            string _output = string.Empty;
            string _guid = string.Empty;
            Guid guid = Guid.NewGuid();

            _guid = _guid + Convert.ToString(guid) + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");

            byte[] _data = Encoding.UTF8.GetBytes(data);
            var _request = cipherRequest(_data);

            string httpUrl = url;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //SAVE REQUEST LOG
            //await ErrorLog(_guid, httpUrl, data, _request.ToString(), method, "");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(httpUrl);
            httpWebRequest.Accept = "*/*";
            httpWebRequest.ContentLength = 684;
            httpWebRequest.ContentType = "text/plain";
            httpWebRequest.Method = method;
            httpWebRequest.KeepAlive = false;
            httpWebRequest.Headers.Add("APIKEY", "DSndoKADZn6ikR8dAcH7gHAJtbBsfKHG");
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(_request);
                streamWriter.Flush();
            }

            string _resCode = string.Empty;
            string _decrypt = string.Empty;

            HttpWebResponse httpResponse = null;
            try
            {
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                _resCode = Convert.ToString(httpResponse.StatusCode);
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    _output = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        _resCode = Convert.ToString(response.StatusCode);
                        _output = response.StatusDescription.ToString();
                    }
                    else
                    {
                        _resCode = "No Code Available #1";
                        _output = "";
                    }
                }
                else
                {
                    _resCode = "No Code Available #2";
                    _output = "";
                }
               
                await ErrorLog(uniqueId, httpUrl, data, _output, 1);
                return "{\"MESSAGE\":\"" + _output + "\"}";
            }

            //byte[] _dataDecrypt = Convert.FromBase64String(_output);
           
            _decrypt = RSA.Decrypt(_output);//deCipherRequest(_dataDecrypt);

            await ErrorLog(uniqueId, httpUrl, data, _decrypt, 1);
            return _decrypt;
        }

        public static X509Certificate2 getPublicKey()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            string _textURL = Path.Combine(_path, "icici/ca.crt");// @"C:\Users\User\Desktop\icici\ca.crt";// file provided by bank
            X509Certificate2 cert2 = new X509Certificate2(_textURL);

            return cert2;
        }

        public static X509Certificate2 getPrivateKey()
        {
            string _keyURL = Path.Combine(_path, "icici/pvt.pfx");//@"C:\Users\User\Desktop\icici\pvt.pfx";// file should be in pfx only

            X509Certificate2 cert2 = null;

            try
            {
                cert2 = new X509Certificate2(_keyURL, "0d996da9cdaSIADShUPAyd1da19b0d866b90bc3", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            }
            catch (CryptographicException ex)
            {
                //Console.WriteLine(ex.Message);
                //ErrorLog("", "", "", ex.Message.ToString(), "", "");
            }
            catch (Exception ex)
            {

            }
            return cert2;
        }



        public static string cipherRequest(byte[] stringToEncrypt)
        {
            X509Certificate2 certificate = getPublicKey();
           
            //RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)certificate.PublicKey.Key;

            //byte[] cryptedData = rsa.Encrypt(stringToEncrypt, false);

            //return Convert.ToBase64String(cryptedData);


            System.Security.Cryptography.RSA rsa_helper = (System.Security.Cryptography.RSA)certificate.PublicKey.Key;
            RSAParameters certparams = rsa_helper.ExportParameters(false);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RSAParameters paramcopy = new RSAParameters();
            paramcopy.Exponent = certparams.Exponent;
            paramcopy.Modulus = certparams.Modulus;
            rsa.ImportParameters(paramcopy);
            byte[] cryptedData = rsa.Encrypt(stringToEncrypt, false);
            return Convert.ToBase64String(cryptedData);
        }



        public static string deCipherRequest(byte [] stringToDecrypt)
        {
            X509Certificate2 certificate = getPrivateKey();

            byte[] cryptedData = null;
            try
            {    
                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)certificate.PrivateKey;
                cryptedData = rsa.Decrypt(stringToDecrypt, false);
            }
            catch (Exception ex)
            {
                string abc = ex.Message;
            }

            return Encoding.UTF8.GetString(cryptedData, 0, cryptedData.Length);
        }

        public static async Task<string> ErrorLog(string txnId, string url, string request, string response,int apiId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Url", url));
            parameters.Add(new SqlParameter("@Request", request));
            parameters.Add(new SqlParameter("@Response", response));
            parameters.Add(new SqlParameter("@TxnId", txnId));
            parameters.Add(new SqlParameter("@apiId", apiId));        
            await _iSqlHelper.ExecuteProcedure("SP_dmtApiLogs", parameters.ToArray());
            return "";
        }
    }
}
