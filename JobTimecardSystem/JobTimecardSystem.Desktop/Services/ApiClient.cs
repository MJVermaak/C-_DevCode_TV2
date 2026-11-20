using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Models.JobTimecardSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JobTimecardSystem.Desktop.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public ApiClient(string baseUrl)
        {
            _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        // --- JOBS ---
        public async Task<List<Job>> GetJobsAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Job>>("api/jobs", _jsonOptions);
            return result ?? new List<Job>();
        }

        public async Task<(bool Success, string Error)> CreateJobAsync(Job job)
        {
            var response = await _http.PostAsJsonAsync("api/jobs", job);
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool Success, string Error)> UpdateJobAsync(int id, Job job)
        {
            var response = await _http.PutAsJsonAsync($"api/jobs/{id}", job);
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool Success, string Error)> DeleteJobAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/jobs/{id}");
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        // --- TIMECARDS ---
        public async Task<List<Timecard>> GetTimecardsAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Timecard>>("api/timecards", _jsonOptions);
            return result ?? new List<Timecard>();
        }

        public async Task<(bool Success, string Error)> CreateTimecardAsync(Timecard timecard)
        {
            var response = await _http.PostAsJsonAsync("api/timecards", timecard);
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool Success, string Error)> UpdateTimecardAsync(int id, Timecard timecard)
        {
            var response = await _http.PutAsJsonAsync($"api/timecards/{id}", timecard);
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool Success, string Error)> DeleteTimecardAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/timecards/{id}");
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        // --- CLIENTS ---
        public async Task<List<Client>> GetClientsAsync(string? search = null)
        {
            var url = string.IsNullOrWhiteSpace(search)
                ? "api/clients"
                : $"api/clients?search={Uri.EscapeDataString(search)}";
            var result = await _http.GetFromJsonAsync<List<Client>>(url, _jsonOptions);
            return result ?? new List<Client>();
        }

        public async Task<(bool Success, string Error)> CreateClientAsync(Client client)
        {
            var response = await _http.PostAsJsonAsync("api/clients", client);
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool Success, string Error)> UpdateClientAsync(int id, Client client)
        {
            var response = await _http.PutAsJsonAsync($"api/clients/{id}", client);
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool Success, string Error)> DeleteClientAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/clients/{id}");
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }
        // --- EMPLOYEES ---
        public async Task<List<Employee>> GetEmployeesAsync(string? search = null)
        {
            var url = string.IsNullOrWhiteSpace(search)
                ? "api/employees"
                : $"api/employees?search={Uri.EscapeDataString(search)}";
            var result = await _http.GetFromJsonAsync<List<Employee>>(url, _jsonOptions);
            return result ?? new List<Employee>();
        }

        public async Task<(bool Success, string Error)> CreateEmployeeAsync(Employee employee)
        {
            var response = await _http.PostAsJsonAsync("api/employees", employee);
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool Success, string Error)> UpdateEmployeeAsync(int id, Employee employee)
        {
            var response = await _http.PutAsJsonAsync($"api/employees/{id}", employee);
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

        public async Task<(bool Success, string Error)> DeleteEmployeeAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/employees/{id}");
            if (response.IsSuccessStatusCode) return (true, string.Empty);
            return (false, await response.Content.ReadAsStringAsync());
        }

    }
}
