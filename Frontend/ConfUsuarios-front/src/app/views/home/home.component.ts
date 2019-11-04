import { Component, OnInit, AfterViewInit } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, AfterViewInit {

  constructor() { }

  ngOnInit() {
  }

  // carrega animação na tela inicial
  ngAfterViewInit() {
    // tslint:disable-next-line: only-arrow-functions
    (function (document: any, tag: any) {
      const scriptTag: any = document.createElement(tag); // create a script tag
      const firstScriptTag: any = document.getElementsByTagName(tag)[0]; // find the first script tag in the document
      scriptTag.src = 'assets/main.min.js'; // set the source of the script to your script
      firstScriptTag.parentNode.insertBefore(scriptTag, firstScriptTag); // append the script to the DOM
    }(document, 'script'));
  }
}
