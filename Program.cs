using System.Net.Http.Json;
using System.Runtime.InteropServices;
using mba.apiref;
    
const string baseAPI = "http://localhost:5053/api/";


    Console.WriteLine("Start....");  

     
    Guest guest = new Guest("12345678","Miquel");
    Email email = new Email("mboada35@boscdelacoma.cat", "institut");
    guest.Emails.Add(email);


    using HttpClient client = new HttpClient();  
    await SaveGuest(client,guest);
    await GetGuests(client);
/*
    await SaveEmail(client,email);
    Console.WriteLine("Email saved ****************************************************************");
    await GetEmails(client);
    await UpdateEmail(client,email.email);
    Console.WriteLine("Email updated ****************************************************************");
    await GetEmails(client);
    Console.WriteLine("Email deleted ****************************************************************");
    await DeleteEmail(client,email);
    await GetEmails(client);
    */


static async Task GetGuests(HttpClient client)
{
    HttpResponseMessage response = await client.GetAsync(baseAPI + "Guest");
    ICollection<Guest>? guests = await response.Content.ReadFromJsonAsync<ICollection<Guest>>();
    foreach (Guest g in guests!) {
        Console.WriteLine(g.ToString());
        foreach (Email e in g.Emails) Console.WriteLine(e.ToString());
    }
}

static async Task SaveGuest(HttpClient client, Guest guest)
{
    HttpResponseMessage response = await client.PostAsJsonAsync<Guest>(baseAPI + "Guest", guest);
}
/* 
static async Task SaveEmail(HttpClient client, Email email)
{
    HttpResponseMessage response = await client.PostAsJsonAsync<Email>(baseAPI + "email", email);
}

static async Task UpdateEmail(HttpClient client,string key)
{
    Email? email = await client.GetFromJsonAsync<Email>(baseAPI + "email/" + key);
    email.type = "Feina";
    HttpResponseMessage response = await client.PutAsJsonAsync<Email>(baseAPI + "email/" + key, email);    
}

static async Task GetEmails(HttpClient client)
{
    HttpResponseMessage response = await client.GetAsync(baseAPI + "email");
    ICollection<Email>? emails = await response.Content.ReadFromJsonAsync<ICollection<Email>>();
    foreach (Email e in emails!) Console.WriteLine(e.ToString());
}

static async Task DeleteEmail(HttpClient client, Email email) {
    Email? response = await client.DeleteFromJsonAsync<Email>(baseAPI + "email/" + email.email);
}

 */