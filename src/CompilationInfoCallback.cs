namespace WebGpuSharp;

public delegate void CompilationInfoCallback(
    CompilationInfoRequestStatus status,
    CompilationInfo info
);

public delegate T CompilationInfoCallback<T>(
    CompilationInfoRequestStatus status,
    CompilationInfo info
);

