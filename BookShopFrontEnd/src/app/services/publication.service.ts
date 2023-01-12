import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Publication } from '../models/publication';

const STORE_BASE_URL = 'https://localhost:7201/api/Publication';

@Injectable({
  providedIn: 'root'
})
export class PublicationService {

  constructor(private httpClient: HttpClient) { }

  getAllPublications(): Observable<Array<Publication>> {
    return this.httpClient.get<Array<Publication>>(`${STORE_BASE_URL}/all`);
  }

  createPublication(publication: Publication){
    return this.httpClient.post(`${STORE_BASE_URL}/create`, publication)
  }

  deletePublication(id: number){
    return this.httpClient.delete(`${STORE_BASE_URL}/delete?id=` + id)
  }

  findPublication(name: string): Observable<any>{
    return this.httpClient.get(`${STORE_BASE_URL}/getByName?name=` + name)
  }
}
