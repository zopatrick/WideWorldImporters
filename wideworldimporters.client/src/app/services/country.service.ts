import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country } from '../models/country.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private apiUrl = `${environment.apiUrl}/country`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Country[]> {
    return this.http.get<Country[]>(this.apiUrl);
  }

  getById(id: number): Observable<Country> {
    return this.http.get<Country>(`${this.apiUrl}/${id}`);
  }

  create(country: Country): Observable<Country> {
    return this.http.post<Country>(this.apiUrl, country);
  }

  update(country: Country): Observable<Country> {
    return this.http.put<Country>(`${this.apiUrl}/${country.countryId}`, country);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
