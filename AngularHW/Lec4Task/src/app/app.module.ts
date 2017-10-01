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

@NgModule({
    declarations: [
        AppComponent,
        BooksListComponent,
        FavoriteComponent,
        HighlightDirective,
        UnlessDirective,
        BytesPipe
    ],
    imports: [
        BrowserModule,
        HttpModule
    ],
    providers: [BooksService],
    bootstrap: [AppComponent]
})
export class AppModule { }
