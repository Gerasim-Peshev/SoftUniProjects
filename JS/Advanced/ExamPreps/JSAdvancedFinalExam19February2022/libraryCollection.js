class LibraryCollection{
    constructor(capacity){
        this.capacity = capacity;
        this.books = []; 
    }

    addBook(bookName, bookAuthor){
        if(this.books.length + 1 > this.capacity){
            throw new Error('Not enough space in the collection.');
        } else {
            this.books.push({bookName, bookAuthor, payed: false});
            return `The ${bookName}, with an author ${bookAuthor}, collect.`;
        }
    }

    payBook(bookName){
        let bookToFind = this.books.find(x => x.bookName === bookName);

        if(!bookToFind){
            throw new Error(`${bookName} is not in the collection.`);
        }

        if(bookToFind.payed){
            throw new Error(`${bookName} has already been paid.`);
        }

        bookToFind.payed = true;
        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName){
        let bookToFind = this.books.find(x => x.bookName === bookName);

        if(!bookToFind){
            throw new Error("The book, you're looking for, is not found.");
        }

        if(!bookToFind.payed){
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books = this.books.filter(x => x !== bookToFind);

        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor){

        let srtToRet = '';

        let arrOfBooks = undefined;
        
        if(bookAuthor === undefined){
            srtToRet += `The book collection has ${this.capacity - this.books.length} empty spots left.\n`;

            arrOfBooks = this.books.sort((a, b) => a.bookName > b.bookName ? 1 : a.bookName < b.bookName ? -1 : 0);

            for(let book of arrOfBooks){
                srtToRet += `${book.bookName} == ${book.bookAuthor} - ${book.payed === true ? 'Has Paid' : 'Not Paid'}.\n`;
            }
        } else {

            arrOfBooks = this.books.filter(x => x.bookAuthor === bookAuthor);
            if(arrOfBooks.length === 0){
                throw new Error(`${bookAuthor} is not in the collection.`);
            }

            arrOfBooks = arrOfBooks.sort((a, b) => a.bookName > b.bookName ? 1 : a.bookName < b.bookName ? -1 : 0);
            for(let book of arrOfBooks){
                srtToRet += `${book.bookName} == ${book.bookAuthor} - ${book.payed === true ? 'Has Paid' : 'Not Paid'}.\n`;
            }
        }

        srtToRet = srtToRet.slice(0, srtToRet.length - 1);
        return srtToRet;
    }
}

const library = new LibraryCollection(2)
//console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
console.log(library.getStatistics('Miguel de Cervantes'));








