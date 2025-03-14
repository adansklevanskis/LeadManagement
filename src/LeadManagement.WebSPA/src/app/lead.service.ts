import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

export interface Lead {
  id: number;
  firstName: string;
  lastName: string;
  dateCreated: string;
  suburb: string;
  category: string;
  description: string;
  price: number;
  status: string;
  email?: string;
  phone?: string;
}
@Injectable({
  providedIn: 'root'
})
export class LeadService {
  private baseUrl = environment.apiUrl + '/leads';

  constructor(private http: HttpClient) {}

  getLeadsByStatus(status: string): Observable<Lead[]> {
    return this.http.get<Lead[]>(`${this.baseUrl}/${status}`);
  }

  acceptLead(id: number): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/${id}/accept`, {});
  }

  declineLead(id: number): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/${id}/decline`, {});
  }
}