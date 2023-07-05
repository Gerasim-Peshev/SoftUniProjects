const host = "http://localhost:3030";

const endPoints = {
  register: "/users/register",
  login: "/users/login",
  logout: "/users/logout",
  createFurniture: "/data/catalog",
  allFurnitures: "/data/catalog",
  furnitureDetails: "/data/catalog/:id",
  updateFurnitures: "/data/catalog/:id",
  deleteFurniture: "/data/catalog/:id",
};

async function createRequest(endPoint, requestType, options) {
  const response = null;

  try {
        if (requestType === "GET" || requestType === "DELETE") {
            response = await fetch(host + endPoint, {
                method: requestType,
                headers: {},
            });
        } else if (requestType === "POST" || "PUT") {

            let tempOpts = {
                method: requestType,
                headers: { "Content-Type": "application/json" }
            }

        }

        if (response.ok === false) {
        let err = response.json();
        throw err;
        }

        let data = await response.json();
        return data;

    } catch (err) {
        alert(err.message);
        throw new Error(err);
    }
}
