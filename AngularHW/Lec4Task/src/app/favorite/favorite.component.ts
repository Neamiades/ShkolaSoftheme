import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-favorite',
    templateUrl: './favorite.component.html'
})
export class FavoriteComponent {
    @Input() favorite: string;
    @Output() favoriteClicked: EventEmitter<string> = new EventEmitter<string>();

    onClick(): void {
        this.favoriteClicked.emit(`${this.favorite} was added to favorites`);
    }
}
