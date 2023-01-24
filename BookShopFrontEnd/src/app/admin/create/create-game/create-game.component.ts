import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrls: ['./create-game.component.css']
})
export class CreateGameComponent {
  game: Game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '', images: [] as string[], keyWords: '', quantity: 0 };
  isUploaded = false;
  shortLink: string = "";
  loading: boolean = false;
  file?: File;

  constructor(
    private http: HttpClient,
    private router: Router,
    private gameService: GameService) { }

  upload(file: any): Observable<any> {
    const formData = new FormData();
    formData.append("file", file, file.name);
    this.isUploaded = true;
    return this.http.post('https://localhost:7201/api/Files/Images', formData).pipe(
        catchError(error => {
          console.error(error);
          if (error.status == 401 || error.status == 403) {
            this.router.navigate(['home'])
            window.alert('You are unauthorize!')
          }
          return throwError(error);
        }))
  }

  onChange(event: any) {

    this.file = event.target.files[0];
  }

  onUpload() {

    this.loading = !this.loading;
    console.log(this.file);

    this.upload(this.file).subscribe(
      (event: any) => {
        console.log(event);
        console.log(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        this.game.images.push(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        if (typeof (event) === 'object') {
          this.shortLink = event.link;
          this.loading = false; // Flag variable
        }
      }
    );
  }

  createGame() {
    this.gameService.createGame(this.game).pipe(
      catchError(error => {
        console.error(error);
        if (error.status == 401 || error.status == 403) {
          window.alert('You are unauthorize!')
          this.router.navigate(['home'])
        }
        return throwError(error);
      })).subscribe(res => console.log(res));
    this.router.navigate(['home'])
  }
}
