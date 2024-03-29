import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, Subscription, throwError } from 'rxjs';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-update-game',
  templateUrl: './update-game.component.html',
  styleUrls: ['./update-game.component.css']
})
export class UpdateGameComponent {
  @ViewChild('gameFindForm') gameFindForm: any;
  submitted: boolean = false;
  gamesSubsription: Subscription | undefined;
  game: Game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '',images: [] as string[], keyWords: '', quantity: 0,};
  gameToUpdate: Game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '',images: [] as string[], keyWords: '', quantity: 0,};
  shortLink: string = "";
  loading: boolean = false; // Flag variable
  isUploaded = false;
  gameId = {
    id: 0,
  };
  gameName = {
    name: '',
  };

  constructor(
    private gameService: GameService,
    private router: Router,
    private http: HttpClient,) {
  }

  findGame() {
    this.gamesSubsription = this.gameService
      .findGame(this.gameName.name)
      .subscribe((_game) => {
        this.game = _game;
        console.log(_game)
      });
    this.resetForm();
  }

  resetForm() {
    this.gameName = { name: "" };
    this.game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '',images: [] as string[], keyWords: '', quantity: 0,};
    this.gameFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.gamesSubsription) {
      this.gamesSubsription.unsubscribe();
    }
  }

  file?: File; // Variable to store file
  upload(file: any): Observable<any> {
    const formData = new FormData();
    formData.append("file", file, file.name);
    this.isUploaded = true;
    return this.http.post('https://localhost:7201/api/Files/Images', formData).pipe(
      catchError(error => {
        console.error(error);
        if (error.status == 401 || error.status == 403) {
          window.alert('You are unauthorize!')
          this.router.navigate(['home'])
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
        this.gameToUpdate.images.push(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        if (typeof (event) === 'object') {
          this.shortLink = event.link;
          this.loading = false; // Flag variable
        }
      }
    );
  }

  updateGame() {
    this.gameService.UpdateGame(this.gameToUpdate, this.game.id).pipe(
      catchError(error => {
        console.error(error);
        if (error.status == 401 || error.status == 403) {
          window.alert('You are unauthorize!')
          this.router.navigate(['home'])
        }
        return throwError(error);
      }))
    .subscribe(res => console.log(res));
    this.router.navigate(['/home']);
  }
}
