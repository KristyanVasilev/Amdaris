import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { Game } from 'src/app/models/game';
import { Publication } from 'src/app/models/publication';
import { Utensil } from 'src/app/models/utensil';
import { CartService } from 'src/app/services/cart.service';
import { GameService } from 'src/app/services/game.service';
import { PublicationService } from 'src/app/services/publication.service';
import { UtensilService } from 'src/app/services/utensil.service';

const ROWS_HEIGHT: { [id: number]: number } = { 1: 400, 3: 335, 4: 350 };

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  cols = 3;
  category: string | undefined;
  rowHeight: number = ROWS_HEIGHT[this.cols];
  games: Array<Game> | undefined;
  publications: Array<Publication> | undefined;
  utensils: Array<Utensil> | undefined;
  gamesSubsription: Subscription | undefined;
  publicationsSubsription: Subscription | undefined;
  utensilSubsription: Subscription | undefined;

  constructor(
    private cartService: CartService,
    private gameService: GameService,
    private publicationService: PublicationService,
    private utensilService: UtensilService,) {

    this.onShowCategory('all');
  }

  getGames(): void {
    this.gamesSubsription = this.gameService
      .getAllGames()
      .subscribe((_games) => {
        this.games = _games;
      });
  }

  getPublications(): void {
    this.publicationsSubsription = this.publicationService
      .getAllPublications()
      .subscribe((_publications) => {
        this.publications = _publications;
      });
  }

  getUtensils(): void {
    this.utensilSubsription = this.utensilService
      .getAllUtensils()
      .subscribe((_utensils) => {
        this.utensils = _utensils;
      });
  }

  onColumnsCountChange(colsNum: number): void {
    this.cols = colsNum;
    this.rowHeight = ROWS_HEIGHT[colsNum];
  }

  onShowCategory(newCategory: string): void {
    this.category = newCategory;
    console.log(this.category);
    if (this.category === 'all') {
      this.getGames();
      this.getPublications();
      this.getUtensils();
    }
    if (this.category === 'games') {
      this.getGames();
    }
    if (this.category === 'publications') {     
      this.getPublications();
    } 
    if (this.category === 'for school') {     
      this.getUtensils();
    } 
  }

  onAddToCart(product: any): void {
    this.cartService.addToCart({
      product: product.images,
      name: product.name,
      price: product.price,
      quantity: 1,
      id: product.id,
    });
  }

  ngOnDestroy(): void {
    if (this.gamesSubsription) {
      this.gamesSubsription.unsubscribe();
    }

    if (this.publicationsSubsription) {
      this.publicationsSubsription.unsubscribe();
    }

    if (this.utensilSubsription) {
      this.utensilSubsription.unsubscribe();
    }
  }
}
