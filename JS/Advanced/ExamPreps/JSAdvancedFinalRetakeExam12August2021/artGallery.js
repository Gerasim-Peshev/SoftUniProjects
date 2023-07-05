class ArtGallery {
    constructor(creator){
        this.creator = creator;
        this.possibleArticles =  { "picture":200,"photo":50,"item":250 };
        this.listOfArticles = [];
        this.guests = []; 
    }

    addArticle(articleModel, articleName, quantity){
        let modelToFind = this.possibleArticles[String(articleModel).toLowerCase()];

        if(!modelToFind){
            throw new Error("This article model is not included in this gallery!");
        }

        let articleToFind = this.listOfArticles.find(x => x.articleName === articleName);

        if(articleToFind && articleToFind.articleModel === articleModel){
            articleToFind.quantity += quantity;
        } else if (!articleToFind){
            this.listOfArticles.push({articleModel: articleModel.toLowerCase(), articleName: articleName, quantity: quantity});
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality){
        let guestToFind = this.guests.find(x => x.guestName === guestName);

        if(guestToFind){
            throw new Error(`${guestName} has already been invited.`);
        }

        let pointsToAdd = 0;
        if(personality === 'Vip'){
            pointsToAdd = 500;
        } else if(personality === 'Middle'){
            pointsToAdd = 250;
        } else {
            pointsToAdd = 50;
        }

        this.guests.push({guestName: guestName, points: pointsToAdd, purchaseArticle: 0});

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName){
        let articleToFind = this.listOfArticles.find(x => x.articleName === articleName);

        if(!articleToFind || articleToFind.articleModel !== articleModel){
            throw new Error("This article is not found.");
        }

        if(articleToFind.quantity === 0){
            return `The ${articleName} is not available.`;
        }

        let guestToFind = this.guests.find(x => x.guestName === guestName);
        if(!guestToFind){
            return "This guest is not invited.";
        }

        if(guestToFind.points - this.possibleArticles[articleToFind.articleModel] < 0){
            return "You need to more points to purchase the article.";
        } else {
            guestToFind.points -= this.possibleArticles[articleToFind.articleModel];
            guestToFind.purchaseArticle++;
            articleToFind.quantity--;

            return `${guestToFind.guestName} successfully purchased the article worth ${this.possibleArticles[articleToFind.articleModel]} points.`;
        }
    }

    showGalleryInfo(criteria){
        let srtToRet = '';
        if(criteria === 'article'){
            srtToRet += `Articles information:\n`;

            for(let article of this.listOfArticles){
                srtToRet += `${article.articleModel} - ${article.articleName} - ${article.quantity}\n`;
            }

            srtToRet = srtToRet.slice(0, srtToRet.length - 1);
            return srtToRet;
        } else if(criteria === 'guest'){
            srtToRet += `Guests information:\n`;

            for(let guest of this.guests){
                srtToRet += `${guest.guestName} - ${guest.purchaseArticle}\n`;
            }

            srtToRet = srtToRet.slice(0, srtToRet.length - 1);
            return srtToRet;
        }
    }
}

const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));



