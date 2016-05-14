using System.Linq;
using docAppDomain.Model;

namespace docAppDomain
{
	public interface IDataAccessProvider
	{
		IQueryable<AppointmentEntity> GetAppointments();

		AppointmentEntity GetAppointment(int id);

		void AddAppointment(AppointmentEntity appointment);
	}
}