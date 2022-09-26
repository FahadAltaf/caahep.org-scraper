

using System.IO;
using System.Net.Http.Json;
using System.Text.Json;
using caahep.org_scraper;
using OfficeOpenXml;

List<DataModel> entries = new List<DataModel>();
Console.WriteLine("Please wait downloading data...");
HttpClient client = new HttpClient();
var model = JsonSerializer.Deserialize<Payload>(File.ReadAllText("payload.json"));
var response = await client.PostAsJsonAsync<Payload>("https://search-api.caahep.org/api/programs?code=jTWtFM5JdJXTkfWQKs7aoKS2tDadlFZnSuLT0V1N2CbIr70RiqjabA==", model);
if (response != null)
{
    var result = await response.Content.ReadFromJsonAsync<List<Root>>();
    if (result != null)
    {
        foreach (var item in result)
        {
            var entry = new DataModel
            {
                ProgramUrl = item.programWebsite,
                InstututionUrl = item.institutionWebsite,
                OutcomeUrl = item.outcomesUrl,
                AccredationDate = item.accreditedOn.ToString("MMM dd, yyyy"),
                Address = item.programDirector.address,
                Address2 = item.programDirector.address2,
                AwardLetter = $"https://search-api.caahep.org/api/9157/download-award-letter/{item.awardLetter.fileUrl}?code=jTWtFM5JdJXTkfWQKs7aoKS2tDadlFZnSuLT0V1N2CbIr70RiqjabA==",
                City = item.programDirector.city,
                County = item.programDirector.country,
                // Degree =item.programDirector.d,
                Email = item.programDirector.email,
                InstitutionName = item.institutionName,
                Name = item.name,
                Phone = item.programDirector.phone,
                ProgramDirectorTitle = item.programDirector.title,
                ProgramDirectorFirstName = item.programDirector.firstName,
                ProgramDirectorLastName = item.programDirector.lastName,
                // Status =item.statusId,
                Zip = item.programDirector.zip

            };

            if (item.degreeAssociate)
            {
                entry.Degree = "Associate";
            }
            else if (item.degreeBaccalaureate)
            {
                entry.Degree = "Baccalaureate";
            }
            else if (item.degreeCertificate)
            {
                entry.Degree = "Certificate";
            }
            else if (item.degreeDiploma)
            {
                entry.Degree = "Diploma";
            }
            else if (item.degreeMasters)
            {
                entry.Degree = "Masters";
            }
            entries.Add(entry);
        }
    }
    else
        Console.WriteLine("Unable to parse the result or no data found");
}
else
    Console.WriteLine("Unable to fetch data from server. Please try again.");

if (entries.Count > 0)
{
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    using (var excel = new ExcelPackage())
    {
        var time = DateTime.Now.ToString("yyyyMMddHHmmss");
        var worksheet = excel.Workbook.Worksheets.Add($"Data");
        worksheet.Cells.LoadFromCollection(entries, true);
        excel.SaveAs($"{time}.xlsx");
        Console.WriteLine($"Data has been exported");
    }
}

Console.ReadKey();
Console.WriteLine("Press any key to exit...");