﻿using System;

namespace docAppDomain.Model
{
	public class AppointmentEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }		
		public string Email { get; set; }
		public string Reason { get; set; }
		public DateTime AppointmentDate { get; set; }
		public string AppointmentTime { get; set; }
	}
}