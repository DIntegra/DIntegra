/*
DIntegra chat module 
Главное окошко 

24.09.2014 - создан
*/

function MWin() {
    this.Title = "MWin";
    this.container = "";
}

MWin.prototype.ToString = function () {
    return this.Title;
}

MWin.prototype.Create = function ($block) {
    var self = this;

    self.container = &block;
}
