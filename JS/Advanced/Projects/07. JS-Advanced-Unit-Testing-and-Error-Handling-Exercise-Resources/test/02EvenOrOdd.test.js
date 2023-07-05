let {assert} = require("chai");
let {isOddOrEven} = require("../02EvenOrOdd");

describe("tests", () => {
    describe("undefine return", () => {
        it("invalid input with undefine", () => {
            assert.equal(isOddOrEven(undefined), undefined)
        }),

        it("invalid input with null", () => {
            assert.equal(isOddOrEven(null), undefined)
        }),

        it("invalid input with arr", () => {
            assert.equal(isOddOrEven([]), undefined)
        }),

        it("invalid input with number", () => {
            assert.equal(isOddOrEven(4), undefined)
        }),

        it("invalid input with boolean", () => {
            assert.equal(isOddOrEven(true), undefined)
        }),

        it("invalid input with empty object", () => {
            assert.equal(isOddOrEven({}), undefined)
        }),

        it("invalid input with object property", () => {
            assert.equal(isOddOrEven({name: 'Sof'}), undefined)
        })
    }),

    describe("valid inputs", () => {
        it("valid even imput", () => {
            assert.equal(isOddOrEven('Anna'), 'even')
        }),

        it("valid odd input", () => {
            assert.equal(isOddOrEven('Maria'), 'odd')
        })
    })
})