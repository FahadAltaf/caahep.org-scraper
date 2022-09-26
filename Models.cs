using System;
namespace caahep.org_scraper
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class AddOnTrack
    {
        public int addOnTrackId { get; set; }
        public string title { get; set; }
    }

    public class AwardLetter
    {
        public int documentId { get; set; }
        public string title { get; set; }
        public string fileUrl { get; set; }
        public string fileDownloadName { get; set; }
    }

    public class ProgramDirector
    {
        public int peopleId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string extension { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public bool active { get; set; }
        public double? lng { get; set; }
        public double? lat { get; set; }
    }

    public class Root
    {
        public int id { get; set; }
        public int professionId { get; set; }
        public List<AddOnTrack> addOnTracks { get; set; }
        public string concentrationTitle { get; set; }
        public string name { get; set; }
        public string institutionName { get; set; }
        public string institutionWebsite { get; set; }
        public bool degreeDiploma { get; set; }
        public bool degreeCertificate { get; set; }
        public bool degreeAssociate { get; set; }
        public bool degreeBaccalaureate { get; set; }
        public bool degreeMasters { get; set; }
        public DateTime accreditedOn { get; set; }
        public int statusId { get; set; }
        public DateTime? statusEffectiveDate { get; set; }
        public string programWebsite { get; set; }
        public string outcomesUrl { get; set; }
        public bool distance { get; set; }
        public bool futureVoluntaryWithdraw { get; set; }
        public ProgramDirector programDirector { get; set; }
        public AwardLetter awardLetter { get; set; }
        public List<Satellite> satellites { get; set; }
    }

    public class Satellite
    {
        public int satelliteId { get; set; }
        public int programId { get; set; }
        public string title { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Paging
    {
        public int pageNumber { get; set; }
        public int maxPageSize { get; set; }
        public int pageSize { get; set; }
    }

    public class Payload
    {
        public string searchText { get; set; }
        public bool isInternational { get; set; }
        public List<int> professionIds { get; set; } = new List<int>();
        public List<int> concentrations { get; set; } = new List<int>();
        public List<int> addOnTracks { get; set; } = new List<int>();
        public List<int> sortStatuses { get; set; } = new List<int>();
        public bool degreeDiploma { get; set; }
        public bool degreeAssociate { get; set; }
        public bool degreeBaccalaureate { get; set; }
        public bool degreeCertificate { get; set; }
        public bool degreeMasters { get; set; }
        public Paging paging { get; set; }
    }


    public class DataModel
    {
        public string ProgramUrl { get; set; }
        public string InstututionUrl { get; set; }
        public string OutcomeUrl { get; set; }
        public string InstitutionName { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string AccredationDate { get; set; }
        public string Degree { get; set; }
        public string AwardLetter { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Zip { get; set; }
        public string ProgramDirectorTitle { get; set; }
        public string ProgramDirectorFirstName { get; set; }
        public string ProgramDirectorLastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }


}

