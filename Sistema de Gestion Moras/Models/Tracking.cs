using System;
using System.Threading;

public class Tracking
{
	public Tracking()
	{
		public int IdTracking {  get; set; }
	    public DateTime DateTracking { get; set; }
	    public required int IdSalesbilling { get; set; }
	    public required Salesbilling Salesbilling { get; set; }
	    public required int IdState { get; set; }
	    public required State State { get; set; }
    }
}
