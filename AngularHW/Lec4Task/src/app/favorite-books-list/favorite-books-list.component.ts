import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { FavoriteBook } from '../models/favorite-book.model';
import { FavoriteBooksService } from '../services/favorite-books.service';

@Component({
  selector: 'app-favorite-books-list',
  templateUrl: './favorite-books-list.component.html',
  styleUrls: ['./favorite-books-list.component.css']
})
export class FavoriteBooksListComponent implements OnInit {
  favoriteMessage = 'The most favorite books of year:';

  favorites$: Observable<FavoriteBook[]>;

  constructor(private favoriteBooksService: FavoriteBooksService) {
  }

  ngOnInit() {
      this.favorites$ = this.favoriteBooksService.getFavoriteBooks();
  }

  onDelFavorite(bookId: number): void {
    this.favoriteBooksService.delFavoriteBook(bookId);
  }
}
