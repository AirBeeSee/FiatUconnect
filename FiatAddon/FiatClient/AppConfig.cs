using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FiatUconnect;

public record AppConfig
{
  [Required(AllowEmptyStrings = false)] public string FiatUser { get; set; } = null!;
  [Required(AllowEmptyStrings = false)] public string FiatPw { get; set; } = null!;
  public string? FiatPin { get; set; }
  [Required(AllowEmptyStrings = false)] public string MqttServer { get; set; } = null!;
  [Range(1, 65536)] public int MqttPort { get; set; } = 1883;
  public string MqttUser { get; set; } = "";
  public string MqttPw { get; set; } = "";
  [Range(1, 1440)] public int RefreshInterval { get; set; } = 2;
  
  [Required(AllowEmptyStrings = false)]
  public string SupervisorToken { get; set; } = null!;

  public FcaBrand Brand { get; set; }
  public FcaRegion Region { get; set; } = FcaRegion.Europe;

  public string HomeAssistantUrl { get; set; } = "http://supervisor/core";
  public int StartDelaySeconds { get; set; } = 2; 

  public bool Debug { get; set; } = false;
  public bool AutoDeepRefresh { get; set; } = false;

  [Range(1, 1440)] public int AutoDeepInterval { get; set; } = 15;
  


  public string ToStringWithoutSecrets()
  {
    var user = this.FiatUser[0..2] + new string('*', this.FiatUser[2..].Length);

    var tmp = this with
    {
      FiatUser = user,
      SupervisorToken = new string('*', this.SupervisorToken.Length),
      FiatPw = new string('*', this.FiatPw.Length),
      MqttPw = new string('*', this.MqttPw.Length),
      FiatPin = new string('*', this.FiatPin?.Length ?? 0),
    };

    return JsonConvert.SerializeObject(tmp, Formatting.Indented, new StringEnumConverter());
  }
  
  public bool IsPinSet()
  {
    return !string.IsNullOrWhiteSpace(this.FiatPin);
  }
}
