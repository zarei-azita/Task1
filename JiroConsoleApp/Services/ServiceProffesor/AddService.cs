using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceProfessor;

namespace JiroConsoleApp.Services.ServiceProffesor
{
    public class AddService: IAddProffesor
    {
        public string AddProfessor(Professor professor)
        {
            int index = Create.professors.FindIndex(p => p.IdProfessor == professor.IdProfessor);
            if (index >= 0)
            {
                return "A professor with this ID has already been added";
            }
            else
            {
                Create.professors.Add(professor);
                return "The professor has been successfully added to the list";
            }
        }
    }
}
