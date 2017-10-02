import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BooksListComponent } from './books-list/books-list.component';
import { FavoriteComponent } from './favorite/favorite.component';
import { HighlightDirective } from './directives/highlight.directive';
import { UnlessDirective } from './directives/unless.directive';
import { BytesPipe } from './pipes/bytes.pipe';
import { HttpModule } from '@angular/http';
import { BooksService } from './services/books.service';
import { FavoriteBooksService } from './services/favorite-books.service';
import { FavoriteBooksListComponent } from './favorite-books-list/favorite-books-list.component';

@NgModule({
    declarations: [
        AppComponent,
        BooksListComponent,
        FavoriteComponent,
        HighlightDirective,
        UnlessDirective,
        BytesPipe,
        FavoriteBooksListComponent
    ],
    imports: [
        BrowserModule,
        HttpModule
    ],
    providers: [BooksService, FavoriteBooksService],
    bootstrap: [AppComponent]
})
export class AppModule { }
