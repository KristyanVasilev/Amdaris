import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-delete-game',
  templateUrl: './delete-game.component.html',
  styleUrls: ['./delete-game.component.css']
})
export class DeleteGameComponent {
  @ViewChild('gameFindForm') gameFindForm: any;
  submitted: boolean = false;
  gamesSubsription: Subscription | undefined;
  game: Game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '',images: [] as string[], keyWords: '', quantity: 0,};
  gameId = {
    id: 0,
  };
  gameName = {
    name: '',
  };

  constructor(
    private gameService: GameService,
    private router: Router) {

  }
  deleteGame() {
    this.gamesSubsription = this.gameService
      .deleteGame(this.gameId.id)
      .subscribe((res) => {
        console.log(res)
      });
    this.router.navigate(['home']);
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
    this.game= { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '',images: [] as string[], keyWords: '', quantity: 0,};
    this.gameFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.gamesSubsription) {
      this.gamesSubsription.unsubscribe();
    }
  }
}
