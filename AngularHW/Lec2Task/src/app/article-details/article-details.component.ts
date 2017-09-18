import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css']
})
export class ArticleDetailsComponent {
  heading: string = "";
  isClicked: boolean = false;
  id: number = 1;
  title: string = "Як знімали рекламу Apple в Україні";
  shortDescription: string = "Режисер кліпу Rolling in the Deep, скейтер" +
                             "з іспанії та оператор на роликах з Південної " +
                             "Африки";
  changeColor(): void {
    this.isClicked = !this.isClicked;
}
}
