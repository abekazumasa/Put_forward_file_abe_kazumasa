<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::middleware('auth:api')->get('/user', function (Request $request) {
    return $request->user();
});
use App\Http\Controllers\ShopController;
Route::get('/shops',[ShopController::class,'index']);
Route::middleware('auth:api')->get('/shops/{shop_id}',[ShopController::class,'show']);
Route::middleware('auth:api')->put('/shops/{shop_id}',[ShopController::class,'update']);
use App\Http\Controllers\ItemController;
Route::middleware('auth:api')->post('/items',[ItemController::class,'store']);
Route::middleware('auth:api')->get('/items/{item_id}',[ItemController::class,'show']);
Route::middleware('auth:api')->put('/items/{item_id}',[ItemController::class,'update']);
Route::middleware('auth:api')->delete('/items/{item_id}',[ItemController::class,'destroy']);
use App\Http\Controllers\OrderController;
Route::post('/order/{shop_id}',[OrderController::class,'store']);

