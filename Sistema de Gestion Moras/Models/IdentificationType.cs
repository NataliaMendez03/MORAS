using System;
using System.ComponentModel.DataAnnotations.Schema;

public class IdentificationType
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdIdentificationType { get; set; }
    public string IdentifiType { get; set; }
    public bool StateDelete { get; set; }
    public DateTime? ModifyDate { get; set; }

}
