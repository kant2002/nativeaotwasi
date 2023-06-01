# NativeAOT WASI

You need to set `EMSDK` and `WASI_SDK_PATH` env variables.

# LRU

Build test
```
dotnet publish lru -c Release /p:TargetArchitecture=wasm /p:PlatformTarget=AnyCPU --self-contained /p:IsWasiProject=true
dotnet publish lru -c Release /p:TargetArchitecture=wasm /p:PlatformTarget=AnyCPU --self-contained /p:IsWasiProject=false
```

Run tests
```
date ; wasmtime --dir artifacts\bin\lru\release_wasi-wasm\AppBundle artifacts\bin\lru\release_wasi-wasm\AppBundle\lru.wasm --mapdir .::. -- 100 10000000 ; date
date ; wasmtime --wasm-features=threads --wasi-modules=experimental-wasi-threads --dir artifacts\publish\lru\release_wasi-wasm\ artifacts\publish\lru\release_wasi-wasm\lru.wasm --mapdir .::. -- 100 10000000 ; date
```

Results

## NativeAOT-LLVM - 3 seconds
```
> date ; wasmtime --wasm-features=threads --wasi-modules=experimental-wasi-threads --dir artifacts\publish\lru\release_wasi-wasm\ artifacts\publish\lru\release_wasi-wasm\lru.wasm --mapdir .::. -- 100 10000000 ; date 
Fri, Jun  2, 2023  2:19:29 AM
969216
9030784
Fri, Jun  2, 2023  2:19:32 AM
```

## WASI SDK - 55 seconds
```
> date ; wasmtime --dir artifacts\bin\lru\release_wasi-wasm\AppBundle artifacts\bin\lru\release_wasi-wasm\AppBundle\lru.wasm --mapdir .::. -- 100 10000000 ; date
Fri, Jun  2, 2023  2:19:38 AM
969216
9030784
Fri, Jun  2, 2023  2:20:33 AM
```