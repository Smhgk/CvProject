namespace CvProject.Models.ViewModels
{
    public class MainVm
    {
        public List<TblDeneyimler> Deneyimler { get; set; }
        public List<TblHakkinda> Hakkinda { get; set; }
        public List<TblEgitimler> Egitimler { get; set; }
        public List<TblYetenekler> Yetenekler { get; set; }
        public List<TblHobiler> Hobiler { get; set; }
        public List<TblSertifikalar> Sertifikalar { get; set; }
        public List<TblIletisim> Iletisim { get; set; }
        public List<TblSosyalMedya> SosyalMedya { get; set; }

    }
}
