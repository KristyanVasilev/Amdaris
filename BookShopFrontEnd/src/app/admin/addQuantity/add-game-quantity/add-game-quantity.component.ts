import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-add-game-quantity',
  templateUrl: './add-game-quantity.component.html',
  styleUrls: ['./add-game-quantity.component.css']
})
export class AddGameQuantityComponent {
  @ViewChild('addGameQuantityFindForm') gameFindForm: any;
  submitted: boolean = false;
  gamesSubsription: Subscription | undefined;
  game: Game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '', images: [] as string[], keyWords: '', quantity: 0, };
  gameId = {
    id: 0,
    quantity: 0
  };
  gameName = {
    name: '',
  };

  constructor(
    private gameService: GameService,
    private router: Router) {

  }
  addGameQuantity() {
    this.gamesSubsription = this.gameService
    .addGameQuantity(this.gameId.id, this.gameId.quantity)
    .subscribe(res => {
      console.log(res);
      window.alert(res)
    })
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
    this.game = { id: 0, name: '', price: 0, description: '', genre: '', manufacturer: '', images: [] as string[], keyWords: '', quantity: 0, };
    this.gameFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.gamesSubsription) {
      this.gamesSubsription.unsubscribe();
    }
  }
}
