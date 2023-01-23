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

  getUtensilsByKeyWord(keyWord: string): Observable<Array<Utensil>> {
    return this.httpClient.get<Array<Utensil>>(`${STORE_BASE_URL}/getByKeyWord?word=` + keyWord);
  }

  createUtensil(utensil: Utensil) {
    return this.httpClient.post<number>(`${STORE_BASE_URL}/create`, utensil)
  }

  deleteUtensil(id: number) {
    return this.httpClient.post<any>(`${STORE_BASE_URL}/delete?id=`, id)
  }

  UndeleteUtensil(publicationName: string): Observable<Utensil> {
    return this.httpClient.post<Utensil>(`${STORE_BASE_URL}/unDelete?utensilName=${publicationName}`, publicationName)
  }

  findUtensil(name: string): Observable<Utensil> {
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
      Images: utensil.images,
      KeyWords: utensil.keyWords,
      Quantity: utensil.quantity
    }
    return this.httpClient.post<number>(`${STORE_BASE_URL}/update/${id}`, UtensilPostDto);
  }
}
