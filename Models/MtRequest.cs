using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgNetcoreCsSample.Models
{
    public class MtRequest
    {
        public const string GW_USERNAME = "gw-username";
        public const string GW_PASSWORD = "gw-password";
        public const string GW_FROM = "gw-from";
        public const string GW_TO = "gw-to";
        public const string GW_TEXT = "gw-text";
        public const string GW_CODING = "gw-coding";
        public const string GW_DLR_MASK = "gw-dlr-mask";
        public const string GW_DLR_URL = "gw-dlr-url";
        public const string GW_RESP_TYPE = "gw-resp-type";

        [JsonProperty(PropertyName = GW_USERNAME)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = GW_PASSWORD)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = GW_FROM)]
        public string From { get; set; }

        [JsonProperty(PropertyName = GW_TO)]
        public string To { get; set; }

        [JsonProperty(PropertyName = GW_TEXT)]
        public string Text { get; set; }

        [JsonProperty(PropertyName = GW_CODING)]
        public string Coding { get; set; }

        [JsonProperty(PropertyName = GW_DLR_MASK)]
        public string DlrMask { get; set; }

        [JsonProperty(PropertyName = GW_DLR_URL)]
        public string DlrUrl { get; set; }

        [JsonProperty(PropertyName = GW_RESP_TYPE)]
        public string ResponseType { get; set; }

    }
}
