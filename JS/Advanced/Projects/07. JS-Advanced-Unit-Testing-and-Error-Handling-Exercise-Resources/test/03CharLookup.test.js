let {assert} = require("chai");
let {lookupChar} = require("../03CharLookup");

describe("tests", () => {
    describe("invalid input", () => {
        it("invalid string and index", () => {
            assert.equal(lookupChar(7, "Deo"), undefined);
        })

        it("invalid string", () => {
            assert.equal(lookupChar(77, 4), undefined);
        }),

        it("invalid index", () => {
            assert.equal(lookupChar("Deo", "D"), undefined);
        })
    }),

    describe("valid string, invalid index", () => {
        it("incex less than 0", () => {
            assert.equal(lookupChar("Lateo", -7), "Incorrect index");
        }),

        it("incex bigger than lenght", () => {
            assert.equal(lookupChar("Kateo", 77), "Incorrect index");
        })

        it("index is floating number", () => {
            assert.equal(lookupChar("Mateo", 7.7), undefined);
        })
    }),

    describe("valid inputs", () => {
        it("Deivid and 3", () => {
            assert.equal(lookupChar("Deivid", 3), "v");
        }),

        it("divieD and lenght - 1", () => {
            assert.equal(lookupChar("divieD", "divieD".length - 1), "D");
        })
    })
})