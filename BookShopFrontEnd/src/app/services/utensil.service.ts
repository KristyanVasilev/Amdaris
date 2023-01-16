import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Utensil } from '../models/utensil';

const STORE_BASE_URL = 'https://localhost:7201/api/WritingUtensil';

@Injectable({
  providedIn: 'root'
})
export class UtensilService {

  constructor(private httpClient: HttpClient) { }

  getAllUtensils(): Observable<Array<Utensil>> {
    return this.httpClient.get<Array<Utensil>>(`${STORE_BASE_URL}/all`);
  }
}
