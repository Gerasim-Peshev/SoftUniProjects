let {assert, expect} = require("chai");
let {mathEnforcer} = require("../04MathEnforcer");

describe("tests", () => {
    describe("addFive tests", () => {
        it("invalid input", () => {
            assert.equal(mathEnforcer.addFive("Dzhigit"), undefined);
        }),

        it("valid int input", () => {
            assert.equal(mathEnforcer.addFive(8), 13);
        }),

        it("valid floating input", () => {
            assert.equal(mathEnforcer.addFive(8.8), 13.8);
        })

        it("valid negative int input", () => {
            assert.equal(mathEnforcer.addFive(-88), -83);
        }),

        it("valid negative floating input", () => {
            expect(mathEnforcer.addFive(-8.8)).be.closeTo(-3.8, 0.01);
        })
    }),

    describe("subtractTen tests", () => {
        it("invalid input", () => {
            assert.equal(mathEnforcer.subtractTen("Stich"), undefined);
        }),

        it("valid int input", () => {
            assert.equal(mathEnforcer.subtractTen(88), 78);
        }),

        it("valid floating input", () => {
            expect(mathEnforcer.subtractTen(8.8)).to.be.closeTo(-1.2, 0.01);
        }),

        it("valid negative int input", () => {
            assert.equal(mathEnforcer.subtractTen(-8), -18);
        }),

        it("valid negative floating input", () => {
            assert.equal(mathEnforcer.subtractTen(-8.8), -18.8);
        })
    }),

    describe("sum tests", () => {
        it("invalid first number", () => {
            assert.equal(mathEnforcer.sum(8, "Mislis"), undefined);
        }),

        it("invalid second num", () => {
            assert.equal(mathEnforcer.sum("Tamales", 88), undefined);
        }),

        it("valid int numbers", () => {
            assert(mathEnforcer.sum(8, 88), 96);
        }),

        it("valid floating numbers", () => {
            expect(mathEnforcer.sum(8.8, 8.8)).to.be.closeTo(17.6, 0.01)
        }),

        it("valid negative int numbers", () => {
            assert.equal(mathEnforcer.sum(-8, -88), -96);
        }),

        it("valid negative floating numbers", () => {
            assert.equal(mathEnforcer.sum((-8.8), (-8.8)), -17.6);
        })
    })
})