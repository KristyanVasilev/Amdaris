import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from '../models/game';

const STORE_BASE_URL = 'https://localhost:7201/api/Game';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(
    private httpClient: HttpClient) { }

  getAllGames(): Observable<Array<Game>> {
    return this.httpClient.get<Array<Game>>(`${STORE_BASE_URL}/all`);
  }

  addGameQuantity(id: number, quantity: number): Observable<any> {
    return this.httpClient.post<any>(`${STORE_BASE_URL}/Add?quantity=${quantity}`, id);
  }

  getGamesByKeyWord(keyWord: string): Observable<Array<Game>> {
    return this.httpClient.get<Array<Game>>(`${STORE_BASE_URL}/getByKeyWord?word=` + keyWord);
  }

  createGame(game: Game) {
    return this.httpClient.post<number>(`${STORE_BASE_URL}/create`, game)
  }

  deleteGame(id: number) {
    return this.httpClient.post<any>(`${STORE_BASE_URL}/delete?id=`, id)
  }

  findGame(name: string): Observable<Game> {
    return this.httpClient.get<Game>(`${STORE_BASE_URL}/getByName?name=` + name)
  }

  UndeleteGame(gameName: string): Observable<Game> {
    return this.httpClient.post<Game>(`${STORE_BASE_URL}/unDelete?gameName=${gameName}`, gameName)
  }

  UpdateGame(game: Game, id: number): Observable<number> {
    const gamePostDto = {
      Name: game.name,
      Manufacturer: game.manufacturer,
      Price: game.price,
      Description: game.description,
      Genre: game.genre,
      Images: game.images,
      Quantity: game.quantity,
      KeyWords: game.keyWords
    }
    return this.httpClient.post<number>(`${STORE_BASE_URL}/update/${id}`, gamePostDto);
  }
}
