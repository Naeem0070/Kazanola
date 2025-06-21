namespace Kazanola.Models.Repositories
{
    public interface IMakeYourPerfume
    {
        List<Notes> Notes();

        List<PerfumeNoteRelatoin> ActiveNote();


    }
}
