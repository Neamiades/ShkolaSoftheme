import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css']
})
export class ArticleDetailsComponent {
  id = 1;
  title = 'Как снимали рекламу Apple в Украине';
  shortDescription = 'Режиссер клипа Rolling in the Deep, скейтер с Испании ' +
                     'и оператор на роликах с Южной Африки';
  isClicked = false;
  color = 'black';
  heading: string;

  changeColor(): void {
    this.color = this.color === 'black' ? 'green' : 'black';
  }
}
