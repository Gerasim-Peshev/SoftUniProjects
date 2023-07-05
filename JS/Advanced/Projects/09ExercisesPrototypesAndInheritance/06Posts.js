function solution(){
    class Post{
        constructor(title, content){
            this._title = title;
            this._content = content;
        }

        get title(){return this._title;}
        set title(value){this._title = value;}

        get content(){return this._content;}
        set content(value){this._content = value;}

        toString = function(){
            let strToRet = [
            `Post: ${this.title}`,
            `Content: ${this.content}`]

            return strToRet.join('\n');
        }
    }

    class SocialMediaPost extends Post{
        constructor(title, content, likes, dises){
            super(title, content);
            this.likes = likes;
            this.dislikes = dises;
            this.comments = [];
        }

        addComment = function(comment){
            this.comments.push(comment);
        }

        toString = function(){
            let strToRet = [
            `Post: ${this.title}`,
            `Content: ${this.content}`,
            `Rating: ${this.likes - this.dislikes}`,];
            if(this.comments.length > 0){
                strToRet.push(`Comments:`);
                for(let com of this.comments){
                    strToRet.push(` * ${com}`);
                }
            }

            return strToRet.join('\n');
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content);
            this.views = views;
        }

        view = function(){
            this.views++;
            return this;
        }

        toString = function(){
            let strToRet = [
            `Post: ${this.title}`,
            `Content: ${this.content}`,
            `Views: ${this.views}`];

            return strToRet.join('\n');
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}

const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!

let blo = new classes.BlogPost('Stop being Vlado', 'Vlado shani', 6);

blo.view();
blo.view();
blo.view();
blo.view();

console.log(blo.toString());
