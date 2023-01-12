import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-undelete-game',
  templateUrl: './undelete-game.component.html',
  styleUrls: ['./undelete-game.component.css']
})
export class UndeleteGameComponent {
  @ViewChild('UndeleteGameForm') UndeleteGameForm: any;
  submitted: boolean = false;
  gamesSubsription: Subscription | undefined;
  game: Game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '', images: [] };
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
  UndeleteGame() {
    this.gamesSubsription = this.gameService
      .UndeleteGame(this.gameName.name)
      .subscribe((_game) => {
        this.game = _game;
        console.log(_game)
      });
    this.resetForm();
  }

  resetForm() {
    this.gameName = { name: "" };
    this.game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '', images: [] };
    this.UndeleteGameForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.gamesSubsription) {
      this.gamesSubsription.unsubscribe();
    }
  }
}
