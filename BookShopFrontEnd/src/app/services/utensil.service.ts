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

  createUtensil(utensil: Utensil) {
    return this.httpClient.post<number>(`${STORE_BASE_URL}/create`, utensil)
  }

  deleteUtensil(id: number) {
    return this.httpClient.delete<number>(`${STORE_BASE_URL}/delete?id=` + id)
  }

  findUtensil(name: string): Observable<Utensil>{
    return this.httpClient.get<Utensil>(`${STORE_BASE_URL}/getByName?name=` + name)
  }
  
  UpdateUtensil(utensil: Utensil, id: number): Observable<number> {
    const UtensilPostDto = {
      Id: id,
      Name: utensil.name,
      Price: utensil.price,
      Manufacturer: utensil.manufacturer,
      WritingUtensilsType: utensil.writingUtensilsType,
      Color: utensil.color,
      Images: utensil.images
    }
    return this.httpClient.post<number>(`${STORE_BASE_URL}/update/${id}`, UtensilPostDto);
  }
}
