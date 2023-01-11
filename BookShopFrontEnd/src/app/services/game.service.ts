import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from '../models/game';

const STORE_BASE_URL = 'https://localhost:7201/api/Game';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private httpClient: HttpClient) { }

  getAllGames(): Observable<Array<Game>> {
    return this.httpClient.get<Array<Game>>(`${STORE_BASE_URL}/all`);
  }

  createGame(game: Game){
    return this.httpClient.post(`${STORE_BASE_URL}/create`, game)
  }
}
